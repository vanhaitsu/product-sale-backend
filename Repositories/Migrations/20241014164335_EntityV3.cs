using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class EntityV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Product_ProductId",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductSizes",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSizes_ProductId",
                table: "ProductSizes",
                newName: "IX_ProductSizes_ProductID");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "CartItem",
                newName: "ProductSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductSizeID",
                table: "CartItem",
                column: "ProductSizeID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ProductSizes_ProductSizeID",
                table: "CartItem",
                column: "ProductSizeID",
                principalTable: "ProductSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Product_ProductID",
                table: "ProductSizes",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ProductSizes_ProductSizeID",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSizes_Product_ProductID",
                table: "ProductSizes");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_ProductSizeID",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ProductSizes",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSizes_ProductID",
                table: "ProductSizes",
                newName: "IX_ProductSizes_ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductSizeID",
                table: "CartItem",
                newName: "SizeId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductID",
                table: "CartItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItem",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItem",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSizes_Product_ProductId",
                table: "ProductSizes",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
