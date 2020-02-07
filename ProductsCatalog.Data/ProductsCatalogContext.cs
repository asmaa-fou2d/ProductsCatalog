namespace ProductsCatalog.Website
{
    using ProductsCatalog.Website.Entities;
    using System.Data.Entity;

    public class ProductsCatalogContext : DbContext
    {
        public ProductsCatalogContext() : base("ProductsCatalogConnection")
        { }

        public DbSet<Product> Products { get; set; }
    }
}
