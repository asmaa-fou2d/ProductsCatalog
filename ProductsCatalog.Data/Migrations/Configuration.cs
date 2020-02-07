namespace ProductsCatalog.Website.Migrations
{
    using ProductsCatalog.Website.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsCatalog.Website.ProductsCatalogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductsCatalog.Website.ProductsCatalogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            context.Products.AddOrUpdate(
              new Product { Name = "Jacket", Photo = "Jacket.jpg", Price = 1000 },
               new Product { Name = "Dress", Photo = "Dress.jpg", Price = 1000 },
                new Product { Name = "Long Vest", Photo = "LongVest.jpg", Price = 1000 }
            );
        }
    }
}
