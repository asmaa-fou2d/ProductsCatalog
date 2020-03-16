namespace ProductsCatalog.Data.Migrations
{
    using ProductsCatalog.Data.Entities;
    using System.Data.Entity.Migrations;
    using System.Linq;

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


            context.Categories.AddOrUpdate(
              new Category { Name = "Fashion", Photo = "Fashion.jpg" },
             new Category { Name = "Mobiles & Tablets", Photo = "MobilesTablets.jpg" },
             new Category { Name = "Electronics", Photo = "Electronics.jpg" });
            context.SaveChanges();

            context.Products.AddOrUpdate(
                new Product { Name = "Jacket", Photo = "Jacket.jpg", Price = 1000, CategoryId = context.Categories.FirstOrDefault(x => x.Name == "Fashion").Id },
                new Product { Name = "Dress", Photo = "Dress.jpg", Price = 2000, CategoryId = context.Categories.FirstOrDefault(x => x.Name == "Fashion").Id },
                new Product { Name = "Long Vest", Photo = "LongVest.jpg", Price = 3000, CategoryId = context.Categories.FirstOrDefault(x => x.Name == "Fashion").Id },
                new Product { Name = "Apple iPhone 11", Photo = "AppleiPhone11.jpg", Price = 20000, CategoryId = context.Categories.FirstOrDefault(x => x.Name == "Mobiles & Tablets").Id },
                new Product { Name = "Samsung UA65RU7300", Photo = "SamsungUA65RU7300.jpg", Price = 1000, CategoryId = context.Categories.FirstOrDefault(x => x.Name == "Electronics").Id }
           );
            context.SaveChanges();
        }
    }
}
