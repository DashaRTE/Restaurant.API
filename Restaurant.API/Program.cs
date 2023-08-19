using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Restaurant.Core.UseCases;
using Restaurant.Core.UseCases.Customer;
using Restaurant.Core.UseCases.Customer.Delete;
using Restaurant.Core.UseCases.Customer.Edit;
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

builder.Services.AddScoped<CreateCustomerUseCase>();
builder.Services.AddScoped<GetCustomerUseCase>();
builder.Services.AddScoped<EditCustomerUseCase>();
builder.Services.AddScoped<DeleteCustomerUseCase>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(static swaggerUiOptions =>
  swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API"));

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();