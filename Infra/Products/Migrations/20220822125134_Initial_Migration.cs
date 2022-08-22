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
                    ProductId = table.Column<int>(nullable:false)
                }, 
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                }, 
                schema: "ProductSchema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
