using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Products.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema("ProductSchema");
            migrationBuilder.CreateTable("Product", 
                columns: table => new
                {
                    Value = table.Column<int>(nullable:false),
                    StockQuantity = table.Column<int>(nullable:false),
                    ProductId = table.Column<int>(nullable:false),
                    ProductName = table.Column<string>(nullable:false)
                }, 
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                }, 
                schema: "ProductSchema");

            migrationBuilder.InsertData(table: "Product", schema: "ProductSchema",
                columns: new[]
                {
                    "Value",
                    "StockQuantity",
                    "Name"
                },
                values: new object[,]
                {
                    {100, 3, "IPhone"},
                    {200, 4, "Ipad"},
                    {300, 5, "Samsung Galaxy"},
                    {500, 6, "Nokia"},
                    {600, 1, "Colchão"},
                    {200, 5, "Aspirador de pó"},
                    {300, 2, "Air Fryer"}
                });
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
