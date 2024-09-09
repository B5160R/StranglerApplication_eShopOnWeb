using Catalog.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Entities
{
  public class CatalogType : BaseEntity, IAggregateRoot
  {
    public string Type { get; private set; }
    public CatalogType(string type)
    {
      Type = type;
    }
  }
}
