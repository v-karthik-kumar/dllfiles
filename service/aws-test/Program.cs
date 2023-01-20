using aws_test.Interfaces;
using aws_test.Models;
using aws_test.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddDbContext<TodoContext>(options => options.UseSqlServer("Server=get1page-rds-identifier.cqmkvsyazydd.eu-west-3.rds.amazonaws.com,1433; Database=TestDB; Trusted_Connection=False; TrustServerCertificate=True;User ID=get1pgdb; Password=G3t19869;"));    

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
