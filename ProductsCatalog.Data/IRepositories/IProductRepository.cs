using ProductsCatalog.Website.DTOs;
using ProductsCatalog.Website.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Website.IRepositories
{
    public interface IProductRepository
    {
        /// <summary>
        /// Get  all products 
        /// </summary>
        /// <returns>list of products</returns>
        List<ProductDto> GetAllProducts();

        /// <summary>
        /// Creare or update product
        /// </summary>
        /// <param name="productDto">product Dto</param>
        /// <returns>true or false</returns>
        bool CreareOrUpdate(ProductDto productDto);

        /// <summary>
        /// Get product by Id 
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Product data</returns>
        ProductDto GetProduct(int id);

        /// <summary>
        /// Delete product 
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>true or false</returns>
        bool Delete(int id);
    }
}
