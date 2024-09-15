using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using Catalog.Infrastructure.Repository;
using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Api.Endpoints;

public class GetCatalogListEndpoint : Endpoint<GetCatalogListRequest, GetCatalogListResponse>
{
  private readonly IRepository<CatalogItem> _itemRepository;

  public GetCatalogListEndpoint(IRepository<CatalogItem> itemRepository)
  {
    _itemRepository = itemRepository;
  }

  public override void Configure()
  {
    Get("/GetCatalogList");
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetCatalogListRequest request, CancellationToken cancellationToken)
  {
    var result = await _itemRepository.GetAllAsync();
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
