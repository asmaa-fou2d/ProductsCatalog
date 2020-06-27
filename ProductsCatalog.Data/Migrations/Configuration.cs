namespace ProductsCatalog.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProductsCatalog.Data.Entities;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System;

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

            context.Slideshows.AddOrUpdate(
              new Slideshow { Title = "Big Sale", SubTitle = "Up to 70% off", Description = "You love shopping but you don't have enough money?  Don't worry Now you can get any product with 70% off, don't miss it", Photo = "Slideshow.jpg" }
              );
            context.SaveChanges();

            #region Admin

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var admin = new User
                {
                    Email = "admin@gmail.com",
                    UserName = "Admin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = manager.PasswordHasher.HashPassword("Abc@123")
                };
                manager.Create(admin);
                manager.AddToRole(admin.Id, "Admin");
            }
            #endregion

            #region User

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "TestUser"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User
                {
                    Email = "testuser@gmail.com",
                    UserName = "TestUser",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PasswordHash = manager.PasswordHasher.HashPassword("Abc@123")
                };
                manager.Create(user);
                manager.AddToRole(user.Id, "User");
            }

            #endregion

        }
    }
}
