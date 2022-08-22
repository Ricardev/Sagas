using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Order.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema("OrderSchema");
            migrationBuilder.CreateTable("Order", 
                columns: table => new
                { 
                    OrderId = table.Column<int>(nullable:false),
                    Quantity = table.Column<int>(nullable:false),
                    UserId = table.Column<int>(nullable:false),
                    ProductId = table.Column<int>(nullable:false)
                }, 
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                },
                schema: "OrderSchema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
