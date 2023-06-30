using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesMonitor.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class Init_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_PackingList_ShoppingListId",
                schema: "shopping",
                table: "ProductList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackingList",
                schema: "shopping",
                table: "PackingList");

            migrationBuilder.RenameTable(
                name: "PackingList",
                schema: "shopping",
                newName: "ShoppingList",
                newSchema: "shopping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingList",
                schema: "shopping",
                table: "ShoppingList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_ShoppingList_ShoppingListId",
                schema: "shopping",
                table: "ProductList",
                column: "ShoppingListId",
                principalSchema: "shopping",
                principalTable: "ShoppingList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductList_ShoppingList_ShoppingListId",
                schema: "shopping",
                table: "ProductList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingList",
                schema: "shopping",
                table: "ShoppingList");

            migrationBuilder.RenameTable(
                name: "ShoppingList",
                schema: "shopping",
                newName: "PackingList",
                newSchema: "shopping");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackingList",
                schema: "shopping",
                table: "PackingList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductList_PackingList_ShoppingListId",
                schema: "shopping",
                table: "ProductList",
                column: "ShoppingListId",
                principalSchema: "shopping",
                principalTable: "PackingList",
                principalColumn: "Id");
        }
    }
}
