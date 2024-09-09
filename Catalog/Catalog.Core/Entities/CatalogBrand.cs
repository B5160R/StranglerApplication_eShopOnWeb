using Catalog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Entities
{
  public class CatalogBrand : BaseEntity, IAggregateRoot
  {
    public string Brand { get; private set; }
    public CatalogBrand(string brand)
    {
      Brand = brand;
    }
  }
}
