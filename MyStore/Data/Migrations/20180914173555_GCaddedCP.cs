using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyStore.Data.Migrations
{
    public partial class GCaddedCP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroceryProductsID",
                table: "GroceryCart",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryCart_GroceryProductsID",
                table: "GroceryCart",
                column: "GroceryProductsID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCart_GroceryProduct_GroceryProductsID",
                table: "GroceryCart",
                column: "GroceryProductsID",
                principalTable: "GroceryProduct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCart_GroceryProduct_GroceryProductsID",
                table: "GroceryCart");

            migrationBuilder.DropIndex(
                name: "IX_GroceryCart_GroceryProductsID",
                table: "GroceryCart");

            migrationBuilder.DropColumn(
                name: "GroceryProductsID",
                table: "GroceryCart");
        }
    }
}
