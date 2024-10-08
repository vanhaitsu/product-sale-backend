using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_CartID",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CartID",
                table: "Order",
                column: "CartID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_CartID",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CartID",
                table: "Order",
                column: "CartID",
                unique: true);
        }
    }
}
