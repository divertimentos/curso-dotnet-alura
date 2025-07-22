using System.Reflection;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FilmeContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configures Automapper (the newest version, with the latest syntax)
builder.Services.AddAutoMapper(cfg => { }, typeof(Program).Assembly);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();