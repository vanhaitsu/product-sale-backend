using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class updateEntitiesV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Cart_CartID",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "Order",
                newName: "CartItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CartID",
                table: "Order",
                newName: "IX_Order_CartItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_CartItem_CartItemID",
                table: "Order",
                column: "CartItemID",
                principalTable: "CartItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_CartItem_CartItemID",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "CartItemID",
                table: "Order",
                newName: "CartID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CartItemID",
                table: "Order",
                newName: "IX_Order_CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Cart_CartID",
                table: "Order",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
