var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Basket services 
 
app.MapPost("/AddItemToBasket", (string username, int catalogItemId, decimal price, int quantity) =>
{
    return $"AddItemToBasket called with username: {username}, catalogItemId: {catalogItemId}, price: {price}, quantity: {quantity}";
})
.WithName("AddItemToBasket")
.WithOpenApi()
.WithTags("Basket Services");

app.MapDelete("/DeleteBasketAsync", (int basketId) =>
{
    return $"DeleteBasketAsync called with basketId: {basketId}";
})
.WithName("DeleteBasketAsync")
.WithOpenApi()
.WithTags("Basket Services");

app.MapPut("/SetQuantities", (int basketId, Dictionary<string, int> quantities) =>
{
    return $"SetQuantities called with basketId: {basketId}, quantities: {quantities}";
})
.WithName("SetQuantities")
.WithOpenApi()
.WithTags("Basket Services");

app.MapGet("/TransferBasketAsync", (string anonymousId, string userName) =>
{
    return $"TransferBasketAsync called with anonymousId: {anonymousId}, userName: {userName}";
})
.WithName("TransferBasketAsync")
.WithOpenApi()
.WithTags("Basket Services");

// Basket View Model services

app.MapGet("/GetOrCreateBasketForUser", (string userName) =>
{
    return $"GetOrCreateBasketForUser called with userName: {userName}";
})
.WithName("GetOrCreateBasketForUser")
.WithOpenApi()
.WithTags("Basket View Model Services");


app.MapPost("/CreateBasketForUser", (string userId) =>
{
    return $"CreateBasketForUser called with userId: {userId}";
})
.WithName("CreateBasketForUser")
.WithOpenApi()
.WithTags("Basket View Model Services");

// string == BasketItem
app.MapGet("/GetBasketItems", (IReadOnlyCollection<string> basketItems) =>
{
    return $"GetBasketItems called with basketItems: {basketItems}";
})
.WithName("GetBasketItems")
.WithOpenApi()
.WithTags("Basket View Model Services");

app.MapGet("/CountTotalBasketItems", (string username) =>
{
    return $"CountTotalBasketItems called with username: {username}";
})
.WithName("CountTotalBasketItems")
.WithOpenApi()
.WithTags("Basket View Model Services");

app.Run();