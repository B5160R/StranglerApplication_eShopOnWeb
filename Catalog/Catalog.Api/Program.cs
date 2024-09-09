using Catalog.Infrastructure.Data;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CatalogContext>(c =>
{
  var connectionString = builder.Configuration[builder.Configuration["AZURE_SQL_CATALOG_CONNECTION_STRING_KEY"] ?? ""];
  c.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure());
});


builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(); 

var app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
