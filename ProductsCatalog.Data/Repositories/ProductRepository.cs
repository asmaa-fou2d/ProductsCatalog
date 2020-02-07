using AutoMapper;
using ProductsCatalog.Website.DTOs;
using ProductsCatalog.Website.Entities;
using ProductsCatalog.Website.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Website.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsCatalogContext _context;

        public ProductRepository(ProductsCatalogContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public List<ProductDto> GetAllProducts()
        {
            return Mapper.Map<List<ProductDto>>(_context.Products.OrderByDescending(p => p.Id).ToList());
        }

        /// <inheritdoc />
        public bool CreareOrUpdate(ProductDto productDto)
        {
            _context.Products.AddOrUpdate(Mapper.Map<Product>(productDto));
            _context.SaveChanges();
            return true;
        }

        /// <inheritdoc />
        public ProductDto GetProduct(int id)
        {
            return Mapper.Map<ProductDto>(GetProductEntity(id));
        }

        /// <inheritdoc />
        public bool Delete(int id)
        {
            var product = GetProductEntity(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;

        }

        /// <summary>
        /// Get product by id 
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>product entity model</returns>
        private Product GetProductEntity(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }
    }
}
