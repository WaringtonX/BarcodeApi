using BarCodeApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using BarCodeApi.Interface;
using BarCodeApi.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject DBContext 
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CoreDbContext>(options => options.EnableSensitiveDataLogging(true).UseSqlServer(connectionstring));

/*builder.Services.AddDbContext<CoreDbContext>(options => options.EnableSensitiveDataLogging(true).UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring), mySqlOptionsAction: sqloptions =>
{
    sqloptions.EnableRetryOnFailure(maxRetryCount: 10,
           maxRetryDelay: TimeSpan.FromSeconds(30),
           errorNumbersToAdd: null);
})); */

builder.Services.AddScoped<IBarCode, BarcodeService>();

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
