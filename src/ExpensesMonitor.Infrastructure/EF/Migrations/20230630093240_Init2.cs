using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesMonitor.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_ShoppingList_ShoppingListId1",
                schema: "shopping",
                table: "ProductList");

            migrationBuilder.DropIndex(
                name: "IX_ProductList_ShoppingListId1",
                schema: "shopping",
                table: "ProductList");

            migrationBuilder.DropColumn(
                name: "ShoppingListId1",
                schema: "shopping",
                table: "ProductList");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingListId1",
                schema: "shopping",
                table: "ProductList",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductList_ShoppingListId1",
                schema: "shopping",
                table: "ProductList",
                column: "ShoppingListId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_ShoppingList_ShoppingListId1",
                schema: "shopping",
                table: "ProductList",
                column: "ShoppingListId1",
                principalSchema: "shopping",
                principalTable: "ShoppingList",
                principalColumn: "Id");
        }
    }
}
