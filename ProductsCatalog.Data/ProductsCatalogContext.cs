namespace ProductsCatalog.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProductsCatalog.Data.Entities;
    using System.Data.Entity;

    public class ProductsCatalogContext : IdentityDbContext<User>
    {
        public ProductsCatalogContext() : base("ProductsCatalogConnection")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Slideshow> Slideshows { get; set; }

        public DbSet<WishList> WishLists { get; set; }
        
    }
}
