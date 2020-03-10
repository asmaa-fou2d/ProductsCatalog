using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsCatalog.Data.IRepositories;
using ProductsCatalog.Data.Repositories;

namespace ProductsCatalog.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductsCatalogContext _productsCatalogContext;

        public IProductRepository Products { get; private set; }


        public UnitOfWork(ProductsCatalogContext productsCatalogContext)
        {
            _productsCatalogContext = productsCatalogContext;
            Products = new ProductRepository(_productsCatalogContext);
        }

        public int Complete()
        {
            return _productsCatalogContext.SaveChanges();
        }

        public void Dispose()
        {
            _productsCatalogContext.Dispose();
        }
    }
}
