using Autofac.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Plugins;
using System.Configuration;
using THD.ERP.App;
using THD.ERP.App.Handlers.Authen;
using THD.ERP.DataAccessor;
using THD.ERP.DataAccessor.Data.Seeds;
using THD.ERP.DataAccessor.Entities;
using THD.ERP.DI;
using THD.ERP.Helper;
using THD.ERP.Infrastructure.Interfaces;
using THD.ERP.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDataAccessorLayer(builder.Configuration);
builder.Services.AddMediatorLayer();
builder.Services.AddBuissinessLayer();
builder.Services.AddSwaggerGen();

var secretKey = builder.Configuration.GetSection("Jwt:Key").Value;
var issuer = builder.Configuration.GetSection("Jwt:Issuer").Value;
var audience = builder.Configuration.GetSection("Jwt:Audience").Value;
builder.Services.AddSingleton<ITokenService>(new TokenService(secretKey!, issuer!, audience!));
var tokenValidationParameters = TokenValidationParametersBuilder.BuildTokenValidationParameters(builder.Configuration);
builder.Services.AddSingleton(tokenValidationParameters);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DefaultEmployees.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();