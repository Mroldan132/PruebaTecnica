using FluentValidation;
using PruebaTecnicaDelosi.Models;
using PruebaTecnicaDelosi.Services;
using PruebaTecnicaDelosi.Validators;

var builder = WebApplication.CreateBuilder(args);

//Servicios.
builder.Services.AddScoped<IMatrizService, MatrizService>();

//Validadores.
builder.Services.AddScoped<IValidator<MatrizCuadrada>, MatrizCuadradaValidator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
