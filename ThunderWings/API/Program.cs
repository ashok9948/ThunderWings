//using Microsoft.EntityFrameworkCore;
using ThunderWings.Application.Interfaces;
using ThunderWings.Application.Services;
using ThunderWings.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register application services
builder.Services.AddScoped<AircraftService>();
builder.Services.AddScoped<BasketService>();
builder.Services.AddScoped<OrderService>();

// Register repositories
builder.Services.AddSingleton<IAircraftRepository, InMemoryAircraftRepository>();
builder.Services.AddSingleton<IBasketRepository, InMemoryBasketRepository>();
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();