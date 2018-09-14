using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyStore.Data.Migrations
{
    public partial class CategoryFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryProduct_Categories_Name",
                table: "GroceryProduct");

            migrationBuilder.DropIndex(
                name: "IX_GroceryProduct_Name",
                table: "GroceryProduct");

            migrationBuilder.RenameColumn(
                name: "GroceryCategoryName",
                table: "GroceryProduct",
                newName: "CategoryName");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GroceryProduct",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "GroceryProduct",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProduct_CategoryName",
                table: "GroceryProduct",
                column: "CategoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryProduct_Categories_CategoryName",
                table: "GroceryProduct",
                column: "CategoryName",
                principalTable: "Categories",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryProduct_Categories_CategoryName",
                table: "GroceryProduct");

            migrationBuilder.DropIndex(
                name: "IX_GroceryProduct_CategoryName",
                table: "GroceryProduct");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "GroceryProduct",
                newName: "GroceryCategoryName");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GroceryProduct",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GroceryCategoryName",
                table: "GroceryProduct",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProduct_Name",
                table: "GroceryProduct",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryProduct_Categories_Name",
                table: "GroceryProduct",
                column: "Name",
                principalTable: "Categories",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
