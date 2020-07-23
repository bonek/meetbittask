using System.Collections.Generic;
using System.Linq;

namespace RTask
{
  class ProductRepository
  {
    private IEnumerable<ProductEntity> _databaseTable = new List<ProductEntity>() { new ProductEntity { ID = "A", Count = 0, Price = 0.65M }, new ProductEntity { ID = "B", Count = 0, Price = 1 } , new ProductEntity { ID = "C", Count = 0, Price = 1.50M } };
       
    public ProductEntity GetProduct(string id)
    {
      return _databaseTable.Single(x => x.ID == id);
    }
  }
}

