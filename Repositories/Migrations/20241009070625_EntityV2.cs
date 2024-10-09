using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class EntityV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_OrderCartItems_OrderCartItemID",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_OrderCartItemID",
                table: "CartItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CartItem_OrderCartItemID",
                table: "CartItem",
                column: "OrderCartItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_OrderCartItems_OrderCartItemID",
                table: "CartItem",
                column: "OrderCartItemID",
                principalTable: "OrderCartItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
