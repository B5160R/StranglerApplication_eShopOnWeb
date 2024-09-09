using Catalog.Core.Specifications;
using FastEndpoints;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;

namespace Catalog.Api.Endpoints;
public class GetCatalogItemDetailsEndpoint : Endpoint<GetCatalogItemDetailsRequest, CatalogItem>
{
  private readonly IRepository<CatalogItem> _itemRepository;


  public override void Configure()
  {
    Get("/GetCatalogItemDetails");
  }

  public override async Task HandleAsync(GetCatalogItemDetailsRequest request, CancellationToken cancellationToken)
  {
    var catalogItemsSpecification = new CatalogItemsSpecification(request.Id);
    var catalogItem = (await _itemRepository.ListAsync(catalogItemsSpecification)).FirstOrDefault();
    if (catalogItem != null) await SendAsync(catalogItem);
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