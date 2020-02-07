using ProductsCatalog.Business.IService;
using ProductsCatalog.Website.DTOs;
using ProductsCatalog.Website.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        /// <inheritdoc />
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <inheritdoc />
        public List<ProductDto> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        /// <inheritdoc />
        public bool CreareOrUpdate(ProductDto productDto)
        {
            return _productRepository.CreareOrUpdate(productDto);
        }

        /// <inheritdoc />
        public ProductDto GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        /// <inheritdoc />
        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }
    }
}
