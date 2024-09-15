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

    public GetCatalogItemDetailsEndpoint(IRepository<CatalogItem> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public override void Configure()
    {
        Get("/GetCatalogItemDetails");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetCatalogItemDetailsRequest request, CancellationToken cancellationToken)
    {
        var result = await _itemRepository.GetByIdAsync(request.Id);

        var response = new GetCatalogItemDetailsResponse { 
            Name = result.Name,
            Description = result.Description
        };

        await SendAsync(result);
    }

}

public class GetCatalogItemDetailsRequest
{
    public int Id { get; set; }
}

public class GetCatalogItemDetailsResponse
{
    public string Name { get; set; }
    public string Description { get; set; }
}
