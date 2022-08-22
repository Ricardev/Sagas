using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Payment.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema("PaymentSchema");
            migrationBuilder.CreateTable("Payment", 
                columns: table => new
            {
                PaymentId = table.Column<int>(nullable: false),
                PaymentValue = table.Column<int>(nullable:false),
                OrderId = table.Column<int>(nullable:false),
                ProductId = table.Column<int>(nullable:false)
            }, 
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                }, 
                schema: "PaymentSchema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
