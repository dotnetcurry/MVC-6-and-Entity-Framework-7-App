using System;

using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using System.ComponentModel.DataAnnotations;

namespace ASP5AppWithEF7.Models
{
    /// <summary>
    /// The Entity class with Product properties
    /// </summary>
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
    }


    /// <summary>
    /// The context class. This uses the Sql Server with the Connection string
    /// defined in the Config.json
    /// </summary>
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptions options)
        {
            options.UseSqlServer(Startup.Configuration.Get("Data:DefaultConnection:ConnectionString"));
            
        }
    }
}