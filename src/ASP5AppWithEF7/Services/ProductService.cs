using System;
using System.Collections.Generic;
using ASP5AppWithEF7.Models;
using System.Linq;
namespace ASP5AppWithEF7.Services
{
    /// <summary>
    /// Interface for defining the methods for performing CRUD operations 
    /// on the Product table
    /// </summary>
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        Product CreateProduct(Product Product);
        Product UpdateProduct(int id, Product Product);
        bool DeleteProduct(int id);
    }
    /// <summary>
    /// The service class containing logic for CRUD operations
    /// </summary>
    public class ProductService : IProductService
    {

        ProductDbContext ctx;

        public ProductService(ProductDbContext c )
        {
            ctx = c;
        }

        public Product CreateProduct(Product Product)
        {
            ctx.Products.Add(Product);
            ctx.SaveChanges();
            return Product;
        }

        public bool DeleteProduct(int id)
        {
            var product = ctx.Products.Where(p => p.ProductId == id).First();
            ctx.Products.Remove(product);
            if (ctx.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }

        public Product GetProduct(int id)
        {
            var product = ctx.Products.Where(p => p.ProductId == id).First();
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return ctx.Products.AsEnumerable();
        }

        public Product UpdateProduct(int id, Product Product)
        {
            var prod = ctx.Products.Where(p => p.ProductId == id).First();

            if (prod != null)
            {
                prod.ProductName = Product.ProductName;
                prod.CategoryName = Product.CategoryName;
                prod.Manufacturer = Product.Manufacturer;
                prod.Price = Product.Price;

                ctx.SaveChanges();
            }
            return prod;
        }
    }
}