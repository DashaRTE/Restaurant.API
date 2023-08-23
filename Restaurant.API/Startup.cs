using Microsoft.OpenApi.Models;
using Restaurant.Core.UseCases.Chef.Create;
using Restaurant.Core.UseCases.Chef.Delete;
using Restaurant.Core.UseCases.Chef.Edit;
using Restaurant.Core.UseCases.Chef.Get;
using Restaurant.Core.UseCases.Chef.GetById;
using Restaurant.Core.UseCases.Customer.Delete;
using Restaurant.Core.UseCases.Customer.Edit;
using Restaurant.Core.UseCases.Customer.GetById;
using Restaurant.Core.UseCases.Customer.GetOrders;
using Restaurant.Core.UseCases.Customer;
using Restaurant.Core.UseCases.Dish.Create;
using Restaurant.Core.UseCases.Dish.Delete;
using Restaurant.Core.UseCases.Dish.Edit;
using Restaurant.Core.UseCases.Dish.Get;
using Restaurant.Core.UseCases.Dish.GetById;
using Restaurant.Core.UseCases.Order.AddDishes;
using Restaurant.Core.UseCases.Order.Create;
using Restaurant.Core.UseCases.Order.Edit;
using Restaurant.Core.UseCases.Order.Get;
using Restaurant.Core.UseCases.Order.GetById;
using Restaurant.Core.UseCases.Order.RemoveDishes;
using Restaurant.Core.UseCases.Owner.Create;
using Restaurant.Core.UseCases.Owner.Delete;
using Restaurant.Core.UseCases.Owner.Edit;
using Restaurant.Core.UseCases.Owner.Get;
using Restaurant.Core.UseCases.Owner.GetById;
using Restaurant.Core.UseCases.Table.Create;
using Restaurant.Core.UseCases.Table.Delete;
using Restaurant.Core.UseCases.Table.Edit;
using Restaurant.Core.UseCases.Table.Get;
using Restaurant.Core.UseCases.Table.GetById;
using Restaurant.Core.UseCases.Table.GetOrders;
using Restaurant.Core.UseCases.Waiter.Create;
using Restaurant.Core.UseCases.Waiter.Delete;
using Restaurant.Core.UseCases.Waiter.Edit;
using Restaurant.Core.UseCases.Waiter.Get;
using Restaurant.Core.UseCases.Waiter.GetById;
using Restaurant.Core.UseCases;
using Restaurant.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastucture;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using AutoMapper;
using Restaurant.Core.Interfaces;
using Restaurant.Infrastucture.Mapping;

namespace Restaurant.API;

public class Startup
{
	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers();

		services.Configure<GzipCompressionProviderOptions>(static options => options.Level = CompressionLevel.Fastest);

		services.AddDbContext<DataContext>(options =>
		{
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")!);
			options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
		});

		services.AddCors(options =>
		{
			options.AddPolicy(name: "_myAllowSpecificOrigins",
				corsPolicyBuilder => { corsPolicyBuilder.AllowAnyMethod().AllowAnyHeader(); });
		});

		services.AddSwaggerGen(options =>
		{
			options.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant API", Version = "v1" });
		});


		services.AddScoped<ICustomerRepository, CustomerRepository>();
		services.AddScoped<IChefRepository, ChefRepository>();
		services.AddScoped<IOwnerRepository, OwnerRepository>();
		services.AddScoped<IWaiterRepository, WaiterRepository>();
		services.AddScoped<ITableRepository, TableRepository>();
		services.AddScoped<IOrderRepository, OrderRepository>();
		services.AddScoped<IDishRepository, DishRepository>();

		//Customer
		services.AddScoped<CreateCustomerUseCase>();
		services.AddScoped<GetCustomerUseCase>();
		services.AddScoped<EditCustomerUseCase>();
		services.AddScoped<DeleteCustomerUseCase>();
		services.AddScoped<GetCustomerByIdUseCase>();
		services.AddScoped<GetCustomerOrdersUseCase>();

		//Chef
		services.AddScoped<GetChefUseCase>();
		services.AddScoped<CreateChefUseCase>();
		services.AddScoped<EditChefUseCase>();
		services.AddScoped<DeleteChefUseCase>();
		services.AddScoped<GetChefByIdUseCase>();

		//Owner
		services.AddScoped<GetOwnerUseCase>();
		services.AddScoped<CreateOwnerUseCase>();
		services.AddScoped<EditOwnerUseCase>();
		services.AddScoped<DeleteOwnerUseCase>();
		services.AddScoped<GetOwnerByIdUseCase>();

		//Waiter
		services.AddScoped<GetWaiterUseCase>();
		services.AddScoped<CreateWaiterUseCase>();
		services.AddScoped<EditWaiterUseCase>();
		services.AddScoped<DeleteWaiterUseCase>();
		services.AddScoped<GetWaiterByIdUseCase>();

		//Table
		services.AddScoped<GetTableUseCase>();
		services.AddScoped<CreateTableUseCase>();
		services.AddScoped<EditTableUseCase>();
		services.AddScoped<DeleteTableUseCase>();
		services.AddScoped<GetTableByIdUseCase>();
		services.AddScoped<GetTableOrdersUseCase>();

		//Dish
		services.AddScoped<GetDishUseCase>();
		services.AddScoped<CreateDishUseCase>();
		services.AddScoped<EditDishUseCase>();
		services.AddScoped<DeleteDishUseCase>();
		services.AddScoped<GetDishByIdUseCase>();

		//Order
		services.AddScoped<GetOrderUseCase>();
		services.AddScoped<CreateOrderUseCase>();
		services.AddScoped<EditOrderUseCase>();
		services.AddScoped<GetOrderByIdUseCase>();
		services.AddScoped<AddDishesUseCase>();
		services.AddScoped<RemoveDishesUseCase>();

		var mappingConfig = new MapperConfiguration(mapperConfigurationExpression =>
		{
			mapperConfigurationExpression.AddProfile(new ChefMapper());
			mapperConfigurationExpression.AddProfile(new CustomerMapper());
			mapperConfigurationExpression.AddProfile(new DishMapper());
			mapperConfigurationExpression.AddProfile(new EntityMapper());
			mapperConfigurationExpression.AddProfile(new OrderMapper());
			mapperConfigurationExpression.AddProfile(new OwnerMapper());
			mapperConfigurationExpression.AddProfile(new TableMapper());
			mapperConfigurationExpression.AddProfile(new UserMapper());
			mapperConfigurationExpression.AddProfile(new WaiterMapper());
		});

		var mapper = mappingConfig.CreateMapper();
		services.AddSingleton(mapper);
	}

	public void Configure(IApplicationBuilder app)
	{
		app.UseSwagger();
		app.UseSwaggerUI(static swaggerUiOptions =>
			swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API"));

		app.UseHttpsRedirection();

		app.UseCors("_myAllowSpecificOrigins");

		app.UseRouting();

		app.UseEndpoints(static endpoints => endpoints.MapControllers());
	}
}
