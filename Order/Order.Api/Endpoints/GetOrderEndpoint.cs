using FastEndpoints;
namespace Order.Api.Endpoints;
public class GetOrderEndpoint : Endpoint<GetOrderRequest, GetOrderResponse>
{
  public override void Configure()
  {
    Get("/GetOrder");
  }

  public override async Task HandleAsync(GetOrderRequest request, CancellationToken cancellationToken)
  {
    var response = await GetOrderAsync();
    await SendAsync(response);
  }

  //placeholder for actual implementation
  private Task<GetOrderResponse> GetOrderAsync()
  {
    return Task.FromResult(new GetOrderResponse { OrderId = 1 });
  }
}

public class GetOrderRequest
{
  public int OrderId { get; set; }
}

public class GetOrderResponse
{
  public int OrderId { get; set; }
}