using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyStore.Data.Migrations
{
    public partial class UpdatingGCP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCart_GroceryProduct_GroceryProductsID",
                table: "GroceryCart");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCartProducts_GroceryCart_GroceryCartID",
                table: "GroceryCartProducts");

            migrationBuilder.DropIndex(
                name: "IX_GroceryCart_GroceryProductsID",
                table: "GroceryCart");

            migrationBuilder.DropColumn(
                name: "GroceryProductsID",
                table: "GroceryCart");

            migrationBuilder.AlterColumn<int>(
                name: "GroceryCartID",
                table: "GroceryCartProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCartProducts_GroceryCart_GroceryCartID",
                table: "GroceryCartProducts",
                column: "GroceryCartID",
                principalTable: "GroceryCart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCartProducts_GroceryCart_GroceryCartID",
                table: "GroceryCartProducts");

            migrationBuilder.AlterColumn<int>(
                name: "GroceryCartID",
                table: "GroceryCartProducts",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCartProducts_GroceryCart_GroceryCartID",
                table: "GroceryCartProducts",
                column: "GroceryCartID",
                principalTable: "GroceryCart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
