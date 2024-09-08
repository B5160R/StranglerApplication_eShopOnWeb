using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Api.Endpoints;
public class GetCatalogItemDetailsEndpoint : Endpoint<GetCatalogItemDetailsRequest, GetCatalogItemDetailsResponse>
{
  public override void Configure()
  {
    Get("/GetCatalogItemDetails");
  }

  public override async Task HandleAsync(GetCatalogItemDetailsRequest request, CancellationToken cancellationToken)
  {
    var response = await GetCatalogItemDetailsAsync();
    await SendAsync(response);
  }

  //placeholder for actual implementation
  private Task<GetCatalogItemDetailsResponse> GetCatalogItemDetailsAsync()
  {
    return Task.FromResult(new GetCatalogItemDetailsResponse { CatalogItemDetails = new CatalogItemDetails { Id = 1, Name = "Item1", Description = "Description1" } });
  }
}

public class GetCatalogItemDetailsRequest
{
  public int Id { get; set; }
}

public class GetCatalogItemDetailsResponse
{
  public string CatalogItemDetails { get; set; }
}