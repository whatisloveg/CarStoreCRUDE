using Microsoft.AspNetCore.Cors.Infrastructure;
using CarStore.Application;
using CarStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using CarStore.DataAccess.Repositories;
using CarStore.Core.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarStoreDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("CarStoreDbContext"));
    });

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
