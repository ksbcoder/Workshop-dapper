using AutoMapper.Data;
using Domain.UseCases.Gateway;
using Domain.UseCases.Gateway.Repository;
using Domain.UseCases.UseCases;
using Infrastructure.DrivenAdapter;
using Infrastructure.DrivenAdapter.Gateway;
using Microsoft.Extensions.Configuration;
using Peliculas.AppService.Automapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));

builder.Services.AddScoped<IDirectorUseCase, DirectorUseCase>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();


builder.Services.AddTransient<IDbConnectionBuilder>(e =>
{
    return new DbConnectionBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
});



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
