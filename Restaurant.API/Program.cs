using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Restaurant.Infrastucture;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(@"Server=DESKTOP-MO999TR;Database=Restaurant;TrustServerCertificate=true;integrated security=True;");
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


//builder.Services.AddScoped<ICrudOperation, CrudOperation>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(static swaggerUiOptions =>
  swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API"));

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();