using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalog.Business.DTOs
{
    public class WishListDto
    {
        public string UserId { get; set; }

        public int ProductId { get; set; }

        public string ProductPhoto { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }
    }
}
