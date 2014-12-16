using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Model;
using System;

namespace ASP5AppWithEF7.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Manufacturer = c.String(),
                        Price = c.Int(nullable: false),
                        ProductName = c.String()
                    })
                .PrimaryKey("PK_Product", t => t.ProductId);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Product");
        }
    }
}