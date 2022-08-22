using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Payment.Migrations
{
    /// <inheritdoc />
    public partial class Add_Constraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey("FK_Order_Product_ProductId", table: "Order" ,"ProductId", 
                principalTable: "Product", principalColumn: "ProductId", principalSchema:"ProductSchema", schema:"OrderSchema");
            migrationBuilder.AddForeignKey("FK_Order_Payment_PaymentId", table: "Payment", "OrderId", 
                schema: "PaymentSchema", principalTable: "Order" , principalColumn: "OrderId", principalSchema: "OrderSchema");
            migrationBuilder.AddForeignKey("FK_Order_Product_ProductId", table: "Payment" ,"PaymentId", 
                schema:"PaymentSchema", principalTable: "Product", principalColumn: "ProductId", principalSchema:"ProductSchema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
