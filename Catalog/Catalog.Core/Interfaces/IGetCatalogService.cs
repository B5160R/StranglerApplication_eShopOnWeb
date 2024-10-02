using Catalog.Core.Entities;

namespace Catalog.Core.Interfaces;
public interface IGetCatalogService
{
  Task<CatalogItem> GetCatalogItemAsync(int id);
  Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync();
}