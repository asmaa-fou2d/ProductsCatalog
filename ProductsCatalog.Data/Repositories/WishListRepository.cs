using ProductsCatalog.Data.Entities;
using ProductsCatalog.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Data.Repositories
{
    public class WishListRepository : GenericRepository<WishList>, IWishListRepository
    {
        public WishListRepository(DbContext context) : base(context)
        {
        }
    }
}
