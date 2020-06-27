using ProductsCatalog.Data.Entities;
using ProductsCatalog.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Data.Repositories
{
    public class SlideshowRepository : GenericRepository<Slideshow>, ISlideshowRepository
    {
        public ProductsCatalogContext _productsCatalogContext => _context as ProductsCatalogContext;

        public SlideshowRepository(ProductsCatalogContext context) : base(context)
        {
        }

    }
}
