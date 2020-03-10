using ProductsCatalog.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using ProductsCatalog.Data.IRepositories;

namespace ProductsCatalog.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductsCatalogContext _productsCatalogContext => _context as ProductsCatalogContext;

        public ProductRepository(ProductsCatalogContext context) : base(context)
        {
        }

        public List<Product> GetProducts(int pageIndex, int pageSize)
        {
            return _productsCatalogContext.Products
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }


        ///// <inheritdoc />
        //public List<ProductDto> GetAllProducts()
        //{
        //    return Mapper.Map<List<ProductDto>>(_context.Products.OrderByDescending(p => p.Id).ToList());
        //}

        ///// <inheritdoc />
        //public bool CreareOrUpdate(ProductDto productDto)
        //{
        //    _context.Products.AddOrUpdate(Mapper.Map<Product>(productDto));
        //    _context.SaveChanges();
        //    return true;
        //}

        ///// <inheritdoc />
        //public ProductDto GetProduct(int id)
        //{
        //    return Mapper.Map<ProductDto>(GetProductEntity(id));
        //}

        ///// <inheritdoc />
        //public bool Delete(int id)
        //{
        //    var product = GetProductEntity(id);
        //    if (product == null)
        //        return false;

        //    _context.Products.Remove(product);
        //    _context.SaveChanges();
        //    return true;

        //}

        ///// <summary>
        ///// Get product by id 
        ///// </summary>
        ///// <param name="id">Product id</param>
        ///// <returns>product entity model</returns>
        //private Product GetProductEntity(int id)
        //{
        //    return _context.Products.SingleOrDefault(p => p.Id == id);
        //}
    }
}
