using Microsoft.EntityFrameworkCore;
using Software_Inmobiliario.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connection = builder.Configuration.GetConnectionString("ConnectionDefault");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connection, MySqlServerVersion.AutoDetect(connection)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

