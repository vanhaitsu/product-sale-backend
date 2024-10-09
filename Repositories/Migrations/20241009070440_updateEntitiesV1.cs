using System;
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
                name: "FK_CartItem_OrderCartItems_OrderCartItemID",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_OrderCartItemID",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "OrderCartItemID",
                table: "CartItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderCartItemID",
                table: "CartItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
