namespace Basket.Api.Endpoints;
public static class BasketEndpoints
{
  public static void MapBasketEndpoints(this IEndpointRouteBuilder endpoints)
  {
    endpoints.MapPost("/AddItemToBasket", (string username, int catalogItemId, decimal price, int quantity) =>
    {
      return $"AddItemToBasket called with username: {username}, catalogItemId: {catalogItemId}, price: {price}, quantity: {quantity}";
    })
    .WithName("AddItemToBasket")
    .WithOpenApi()
    .WithTags("Basket Services");

    endpoints.MapDelete("/DeleteBasketAsync", (int basketId) =>
    {
      return $"DeleteBasketAsync called with basketId: {basketId}";
    })
    .WithName("DeleteBasketAsync")
    .WithOpenApi()
    .WithTags("Basket Services");

    endpoints.MapPut("/SetQuantities", (int basketId, Dictionary<string, int> quantities) =>
    {
      return $"SetQuantities called with basketId: {basketId}, quantities: {quantities}";
    })
    .WithName("SetQuantities")
    .WithOpenApi()
    .WithTags("Basket Services");

    endpoints.MapGet("/TransferBasketAsync", (string anonymousId, string userName) =>
    {
      return $"TransferBasketAsync called with anonymousId: {anonymousId}, userName: {userName}";
    })
    .WithName("TransferBasketAsync")
    .WithOpenApi()
    .WithTags("Basket Services");
  }
}