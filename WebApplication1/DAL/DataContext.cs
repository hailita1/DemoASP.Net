using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataContext")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var categories = new List<Category>
            {
                new Category(){Name = "Domestic"},
                new Category(){Name = "Elictronic"},
                new Category(){Name = "Computer"},
                new Category(){Name = "Food"}
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product(){Name = "HP computer", Price = 123.4f, CategoryId = 3},
                new Product(){Name = "HP printer", Price = 123.4f, CategoryId = 1},
                new Product(){Name = "Hitachi Refrigerator", Price = 123.4f, CategoryId = 2},
                new Product(){Name = "Fruit", Price = 123.4f, CategoryId = 4},
                new Product(){Name = "Egg", Price = 123.4f, CategoryId = 4},
                new Product(){Name = "Water", Price = 123.4f, CategoryId = 4}
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}
