using ProductsCatalog.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using ProductsCatalog.Data.IRepositories;

namespace ProductsCatalog.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductsCatalogContext _productsCatalogContext => _context as ProductsCatalogContext;

        public ProductRepository(ProductsCatalogContext context) : base(context)
        {
        }

        public List<Product> GetProducts(int pageIndex, int pageSize)
        {
            return _productsCatalogContext.Products
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        } 
    }
}
