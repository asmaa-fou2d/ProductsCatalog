using ProductsCatalog.Data.Entities;
using System.Collections.Generic;

namespace ProductsCatalog.Data.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Get  all products 
        /// </summary>
        /// <returns>list of products</returns>
        List<Product> GetProducts(int pageIndex,int pageSize);

        /// <summary>
        /// Creare or update product
        /// </summary>
        /// <param name="productDto">product Dto</param>
        /// <returns>true or false</returns>
       // bool CreareOrUpdate(ProductDto productDto);

        /// <summary>
        /// Get product by Id 
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Product data</returns>
     //   ProductDto GetProduct(int id);

        /// <summary>
        /// Delete product 
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>true or false</returns>
        //bool Delete(int id);
    }
}
