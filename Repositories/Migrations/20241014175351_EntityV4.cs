using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class EntityV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderCartItems_Product_ProductID",
                table: "OrderCartItems");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "OrderCartItems",
                newName: "ProductSizeID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderCartItems_ProductID",
                table: "OrderCartItems",
                newName: "IX_OrderCartItems_ProductSizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCartItems_ProductSizes_ProductSizeID",
                table: "OrderCartItems",
                column: "ProductSizeID",
                principalTable: "ProductSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderCartItems_ProductSizes_ProductSizeID",
                table: "OrderCartItems");

            migrationBuilder.RenameColumn(
                name: "ProductSizeID",
                table: "OrderCartItems",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderCartItems_ProductSizeID",
                table: "OrderCartItems",
                newName: "IX_OrderCartItems_ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderCartItems_Product_ProductID",
                table: "OrderCartItems",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
