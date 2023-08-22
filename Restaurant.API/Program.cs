using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Restaurant.Core.UseCases;
using Restaurant.Core.UseCases.Chef.Create;
using Restaurant.Core.UseCases.Chef.Delete;
using Restaurant.Core.UseCases.Chef.Edit;
using Restaurant.Core.UseCases.Chef.Get;
using Restaurant.Core.UseCases.Chef.GetById;
using Restaurant.Core.UseCases.Customer;
using Restaurant.Core.UseCases.Customer.Delete;
using Restaurant.Core.UseCases.Customer.Edit;
using Restaurant.Core.UseCases.Customer.GetById;
using Restaurant.Core.UseCases.Customer.GetOrders;
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
using Restaurant.Infrastucture;
using Restaurant.Infrastucture.Repositories;
using Restaurant.Infrastucture.Repositories.Interfaces;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(@"Server=DESKTOP-MO999TR;Database=Restaurant;TrustServerCertificate=true;integrated security=True;");
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        corsPolicyBuilder => { corsPolicyBuilder.AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant API", Version = "v1" });
});


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IChefRepository, ChefRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IWaiterRepository, WaiterRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IDishRepository, DishRepository>();

//Customer
builder.Services.AddScoped<CreateCustomerUseCase>();
builder.Services.AddScoped<GetCustomerUseCase>();
builder.Services.AddScoped<EditCustomerUseCase>();
builder.Services.AddScoped<DeleteCustomerUseCase>();
builder.Services.AddScoped<GetCustomerByIdUseCase>();
builder.Services.AddScoped<GetCustomerOrdersUseCase>();

//Chef
builder.Services.AddScoped<GetChefUseCase>();
builder.Services.AddScoped<CreateChefUseCase>();
builder.Services.AddScoped<EditChefUseCase>();
builder.Services.AddScoped<DeleteChefUseCase>();
builder.Services.AddScoped<GetChefByIdUseCase>();

//Owner
builder.Services.AddScoped<GetOwnerUseCase>();
builder.Services.AddScoped<CreateOwnerUseCase>();
builder.Services.AddScoped<EditOwnerUseCase>();
builder.Services.AddScoped<DeleteOwnerUseCase>();
builder.Services.AddScoped<GetOwnerByIdUseCase>();

//Waiter
builder.Services.AddScoped<GetWaiterUseCase>();
builder.Services.AddScoped<CreateWaiterUseCase>();
builder.Services.AddScoped<EditWaiterUseCase>();
builder.Services.AddScoped<DeleteWaiterUseCase>();
builder.Services.AddScoped<GetWaiterByIdUseCase>();

//Table
builder.Services.AddScoped<GetTableUseCase>();
builder.Services.AddScoped<CreateTableUseCase>();
builder.Services.AddScoped<EditTableUseCase>();
builder.Services.AddScoped<DeleteTableUseCase>();
builder.Services.AddScoped<GetTableByIdUseCase>();
builder.Services.AddScoped<GetTableOrdersUseCase>();

//Dish
builder.Services.AddScoped<GetDishUseCase>();
builder.Services.AddScoped<CreateDishUseCase>();
builder.Services.AddScoped<EditDishUseCase>();
builder.Services.AddScoped<DeleteDishUseCase>();
builder.Services.AddScoped<GetDishByIdUseCase>();

//Order
builder.Services.AddScoped<GetOrderUseCase>();
builder.Services.AddScoped<CreateOrderUseCase>();
builder.Services.AddScoped<EditOrderUseCase>();
builder.Services.AddScoped<GetOrderByIdUseCase>();
builder.Services.AddScoped<AddDishesUseCase>();
builder.Services.AddScoped<RemoveDishesUseCase>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(static swaggerUiOptions =>
  swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API"));

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();