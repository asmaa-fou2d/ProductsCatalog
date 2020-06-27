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

        public IProductRepository ProductRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public ISlideshowRepository SlideshowRepository { get; private set; }

        public IWishListRepository WishListRepository { get; private set; }

        public UnitOfWork(ProductsCatalogContext productsCatalogContext)
        {
            _productsCatalogContext = productsCatalogContext;
            ProductRepository = new ProductRepository(_productsCatalogContext);
            CategoryRepository = new CategoryRepository(_productsCatalogContext);
            SlideshowRepository = new SlideshowRepository(_productsCatalogContext);
            WishListRepository = new WishListRepository(_productsCatalogContext);
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
