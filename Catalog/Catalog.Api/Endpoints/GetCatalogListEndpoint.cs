using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Api.Endpoints;
public class GetCatalogListEndpoint : Endpoint<GetCatalogListRequest, GetCatalogListResponse>
{
  public override void Configure()
  {
    Get("/GetCatalogList");
  }

  public override async Task HandleAsync(GetCatalogListRequest request, CancellationToken cancellationToken)
  {
    var response = await GetCatalogListAsync();
    await SendAsync(response);
  }

  //placeholder for actual implementation
  private Task<GetCatalogListResponse> GetCatalogListAsync()
  {
    return Task.FromResult(new GetCatalogListResponse { CatalogList = new[] { "Item1", "Item2" } });
  }
}

public class GetCatalogListRequest
{
}

public class GetCatalogListResponse
{
  public string[] CatalogList { get; set; }
}