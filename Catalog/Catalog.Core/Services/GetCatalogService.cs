using Catalog.Core.Entities;
using Catalog.Core.Interfaces;

namespace Catalog.Core.Services;
public class GetCatalogService(IRepository<CatalogItem> repository,
  ICacheService cache) : IGetCatalogService
{
  private readonly string cacheKey = "CatalogItems";
  public async Task<CatalogItem> GetCatalogItemAsync(int id)
  {
    var catalogItems = await cache.GetCachedDataAsync<IEnumerable<CatalogItem>>(cacheKey);
    if (catalogItems == null)
    {
      // TODO: Implement caching for single item?
      catalogItems = await repository.GetAllAsync();
      await cache.SetCachedDataAsync(cacheKey, catalogItems, TimeSpan.FromMinutes(3));
    }
    return catalogItems.FirstOrDefault(x => x.Id == id);
  }

  public async Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync()
  {;
    var catalogItems = await cache.GetCachedDataAsync<IEnumerable<CatalogItem>>(cacheKey);
    if (catalogItems == null)
    {
      catalogItems = await repository.GetAllAsync();
      await cache.SetCachedDataAsync(cacheKey, catalogItems, TimeSpan.FromMinutes(3));
    }
    return catalogItems;
  }
}