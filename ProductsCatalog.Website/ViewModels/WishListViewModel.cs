using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsCatalog.Website.ViewModels
{
    public class WishListViewModel
    {
        public int ProductId { get; set; }

        public string ProductPhoto { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }
    }
}