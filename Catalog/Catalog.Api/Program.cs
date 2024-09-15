using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using Catalog.Infrastructure.EFCore.Context;
using Catalog.Infrastructure.Repository;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatalogDbContext>(c =>
{
  var connectionString = builder.Configuration[builder.Configuration["AZURE_SQL_CATALOG_CONNECTION_STRING_KEY"] ?? ""];
  c.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure());
});

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(); 

builder.Services.AddScoped<IRepository<CatalogItem>, Repository<CatalogItem>>();

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
