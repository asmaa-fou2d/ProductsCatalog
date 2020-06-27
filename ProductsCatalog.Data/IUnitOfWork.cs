using ProductsCatalog.Data.IRepositories;
using System;

namespace ProductsCatalog.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ISlideshowRepository SlideshowRepository { get; }
        IWishListRepository WishListRepository { get; }

        int Complete();
    }
}
