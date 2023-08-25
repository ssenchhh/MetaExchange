using FluentValidation.AspNetCore;
using FluentValidation;
using MetaExchange.API.Controllers.Requests;
using MetaExchange.API.Validators;
using MetaExchange.Core.Data.Providers.Interfaces;
using MetaExchange.Core.Data.Providers;
using MetaExchange.Core.Data.Repositories.Interfaces;
using MetaExchange.Core.Data.Repositories;
using MetaExchange.Core.Models;
using MetaExchange.Core.Services.Interfaces;
using MetaExchange.Core.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IDataProvider<OrderBook>, RowDataProvider<OrderBook>>();
builder.Services.AddScoped<IRepository<OrderBook>, OrderBookRepository>();
builder.Services.AddScoped<IMetaExchangeService, MetaExchangeService>();

builder.Services.AddScoped<IValidator<ExchangeRequest>, ExchangeRequestValidator>();

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
