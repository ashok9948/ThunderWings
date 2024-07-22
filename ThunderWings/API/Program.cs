using ThunderWings.Application.Interfaces;
using ThunderWings.Application.Services;
using ThunderWings.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register application services for dependency injection
builder.Services.AddScoped<AircraftService>();
builder.Services.AddScoped<BasketService>();
builder.Services.AddScoped<OrderService>();

// Register repositories for dependency injection, using in-memory implementations
builder.Services.AddSingleton<IAircraftRepository, InMemoryAircraftRepository>();
builder.Services.AddSingleton<IBasketRepository, InMemoryBasketRepository>();
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline for development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable authorization middleware
app.UseAuthorization();

// Map controller routes
app.MapControllers();

// Run the application
app.Run();
