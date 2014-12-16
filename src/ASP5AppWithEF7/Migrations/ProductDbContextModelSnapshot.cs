using ASP5AppWithEF7.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using System;

namespace ASP5AppWithEF7.Migrations
{
    [ContextType(typeof(ProductDbContext))]
    public class ProductDbContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("ASP5AppWithEF7.Models.Product", b =>
                    {
                        b.Property<string>("CategoryName");
                        b.Property<string>("Manufacturer");
                        b.Property<int>("Price");
                        b.Property<int>("ProductId")
                            .GenerateValuesOnAdd();
                        b.Property<string>("ProductName");
                        b.Key("ProductId");
                    });
                
                return builder.Model;
            }
        }
    }
}