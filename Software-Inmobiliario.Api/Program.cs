using Microsoft.EntityFrameworkCore;
using Software_Inmobiliario.Applicationn.Interfaces;
using Software_Inmobiliario.Domain.Interfaces;
using Software_Inmobiliario.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Repos y servicios
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Swagger
builder.Services.AddSwaggerGen();

// DbContext
var connection = builder.Configuration.GetConnectionString("ConnectionDefault");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connection, MySqlServerVersion.AutoDetect(connection)));

builder.Services.AddControllers();

var app = builder.Build();

// Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();