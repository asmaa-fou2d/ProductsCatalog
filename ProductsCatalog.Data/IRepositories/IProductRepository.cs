using ProductsCatalog.Data.Entities;
using System.Collections.Generic;

namespace ProductsCatalog.Data.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        /// <summary>
        /// Get  all products 
        /// </summary>
        /// <returns>list of products</returns>
        List<Product> GetProducts(int pageIndex,int pageSize);

        /// <summary>
        /// Get random products
        /// </summary>
        /// <returns>list of products</returns>
        List<Product> GetRandomProducts();
        
    }
}
