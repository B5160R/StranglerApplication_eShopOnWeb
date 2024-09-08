using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Api.Endpoints;
public class CreateOrderEndpoint : Endpoint<CreateOrderRequest, CreateOrderResponse>
{
  public override void Configure()
  {
    Post("/CreateOrder");
  }

  public override async Task HandleAsync(CreateOrderRequest request, CancellationToken cancellationToken)
  {
    var response = await CreateOrderAsync();
    await SendAsync(response);
  }

  //placeholder for actual implementation
  private Task<CreateOrderResponse> CreateOrderAsync()
  {
    return Task.FromResult(new CreateOrderResponse { OrderId = 1 });
  }
}

public class CreateOrderRequest
{
  public string Username { get; set; }
  public int BasketId { get; set; }
  public string ShippingAddress { get; set; }
  public string PaymentMethod { get; set; }
}

public class CreateOrderResponse
{
  public int OrderId { get; set; }
}