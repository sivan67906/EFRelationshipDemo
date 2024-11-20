using EFRelationship.Api.EFRelationship.Api.Application.Mappings;
using EFRelationship.Api.EFRelationship.Api.Application.Services.Implementation;
using EFRelationship.Api.EFRelationship.Api.Application.Services.Interfaces;
using EFRelationship.Api.EFRelationship.Api.Domain.Entities;
using EFRelationship.Api.EFRelationship.Api.Domain.Interfaces;
using EFRelationship.Api.EFRelationship.Api.Infrastructure.DependencyInjection;
using EFRelationship.Api.EFRelationship.Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(MappingConfig));
// Add services to the container.
builder.Services.AddServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();

builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();

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
