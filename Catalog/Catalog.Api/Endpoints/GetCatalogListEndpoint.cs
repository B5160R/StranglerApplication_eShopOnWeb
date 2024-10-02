using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using FastEndpoints;

namespace Catalog.Api.Endpoints;

public class GetCatalogListEndpoint(IGetCatalogService getCatalogService) 
: Endpoint<GetCatalogListRequest, GetCatalogListResponse>
{
  public override void Configure()
  {
    Get("/GetCatalogList");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetCatalogListRequest request, CancellationToken cancellationToken)
  {
    var result = await getCatalogService.GetCatalogItemsAsync();
    var response = new GetCatalogListResponse { CatalogList = result.Select(x => x.Name).ToArray() };
    await SendAsync(response);
  }
}

public class GetCatalogListRequest
{
  public bool DummyProperty { get; set; } = true;
}

public class GetCatalogListResponse
{
  public string[] CatalogList { get; set; }
}
