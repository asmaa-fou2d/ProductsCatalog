using ProductsCatalog.Business.DTOs;
using System.Collections.Generic;


namespace ProductsCatalog.Business.IService
{
    public interface IProductService
    {
        /// <summary>
        /// Get  all products 
        /// </summary>
        /// <returns>list of products</returns>
        List<ProductDto> GetAllProducts();

        /// <summary>
        /// Creare product
        /// </summary>
        /// <param name="productDto">product Dto</param>
        void Creare(ProductDto productDto);

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
        void Delete(int id);

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="productDto">product Dto</param>
        void Update(ProductDto productDto);
    }
}
