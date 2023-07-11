using ExpensesMonitor.Application;
using ExpensesMonitor.Infrastructure;
using ExpensesMonitor.Shared;
using Microsoft.EntityFrameworkCore.Design;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
IConfiguration conf = builder.Configuration;
// Add services to the container.

builder.Services.AddShared();
builder.Services.AddInfrastructures(conf);
builder.Services.AddApplication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseShared();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();