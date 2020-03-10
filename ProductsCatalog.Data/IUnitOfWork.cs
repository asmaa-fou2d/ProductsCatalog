using ProductsCatalog.Data.IRepositories;
using System;

namespace ProductsCatalog.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }

        int Complete();
    }
}
