using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Catalog.Core.Specifications
{
  public class CatalogItemsSpecification : Specification<CatalogItem>
  {
    public CatalogItemsSpecification(params int[] ids)
    {
      Query.Where(c => ids.Contains(c.Id));
    }
  }
}
