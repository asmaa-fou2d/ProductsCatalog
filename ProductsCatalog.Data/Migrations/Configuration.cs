namespace ProductsCatalog.Data.Migrations
{
    using ProductsCatalog.Data.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsCatalogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductsCatalogContext context)
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
