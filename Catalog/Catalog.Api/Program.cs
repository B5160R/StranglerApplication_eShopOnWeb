using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using Catalog.Core.Services;
using Catalog.Infrastructure.EFCore.Context;
using Catalog.Infrastructure.Repository;
using Catalog.Infrastructure.Cache;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CatalogDbContext>(c =>
{
  var connectionString = builder.Configuration.GetConnectionString("CatalogDb");
  c.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure());
});

builder.Services.AddStackExchangeRedisCache(options =>
{
  options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
});

builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(); 

builder.Services.AddScoped<IRepository<CatalogItem>, Repository<CatalogItem>>();
builder.Services.AddScoped<ICacheService, RedisCacheService>();
builder.Services.AddScoped<IGetCatalogService, GetCatalogService>();

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
