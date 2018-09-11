using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyStore.Data.Migrations
{
    public partial class UpdatingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCartProducts_GroceryProductCart_GroceryCartID",
                table: "GroceryCartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsID",
                table: "GroceryCartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryProductCart_AspNetUsers_ApplicationUserID",
                table: "GroceryProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryProductCart_GroceryProduct_GroceryProductsID",
                table: "GroceryProductCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroceryProductCart",
                table: "GroceryProductCart");

            migrationBuilder.RenameTable(
                name: "GroceryProductCart",
                newName: "GroceryCart");

            migrationBuilder.RenameIndex(
                name: "IX_GroceryProductCart_GroceryProductsID",
                table: "GroceryCart",
                newName: "IX_GroceryCart_GroceryProductsID");

            migrationBuilder.RenameIndex(
                name: "IX_GroceryProductCart_ApplicationUserID",
                table: "GroceryCart",
                newName: "IX_GroceryCart_ApplicationUserID");

            migrationBuilder.AlterColumn<int>(
                name: "GroceryProductsID",
                table: "GroceryCartProducts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GroceryCartID",
                table: "GroceryCartProducts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GroceryCartProductsID",
                table: "GroceryCartProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroceryProductID",
                table: "GroceryCartProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroceryCart",
                table: "GroceryCart",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCart_AspNetUsers_ApplicationUserID",
                table: "GroceryCart",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsID",
                table: "GroceryCartProducts",
                column: "GroceryProductsID",
                principalTable: "GroceryProduct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCart_AspNetUsers_ApplicationUserID",
                table: "GroceryCart");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCart_GroceryProduct_GroceryProductsID",
                table: "GroceryCart");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCartProducts_GroceryCart_GroceryCartID",
                table: "GroceryCartProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsID",
                table: "GroceryCartProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroceryCart",
                table: "GroceryCart");

            migrationBuilder.DropColumn(
                name: "GroceryCartProductsID",
                table: "GroceryCartProducts");

            migrationBuilder.DropColumn(
                name: "GroceryProductID",
                table: "GroceryCartProducts");

            migrationBuilder.RenameTable(
                name: "GroceryCart",
                newName: "GroceryProductCart");

            migrationBuilder.RenameIndex(
                name: "IX_GroceryCart_GroceryProductsID",
                table: "GroceryProductCart",
                newName: "IX_GroceryProductCart_GroceryProductsID");

            migrationBuilder.RenameIndex(
                name: "IX_GroceryCart_ApplicationUserID",
                table: "GroceryProductCart",
                newName: "IX_GroceryProductCart_ApplicationUserID");

            migrationBuilder.AlterColumn<int>(
                name: "GroceryProductsID",
                table: "GroceryCartProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroceryCartID",
                table: "GroceryCartProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroceryProductCart",
                table: "GroceryProductCart",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCartProducts_GroceryProductCart_GroceryCartID",
                table: "GroceryCartProducts",
                column: "GroceryCartID",
                principalTable: "GroceryProductCart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsID",
                table: "GroceryCartProducts",
                column: "GroceryProductsID",
                principalTable: "GroceryProduct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryProductCart_AspNetUsers_ApplicationUserID",
                table: "GroceryProductCart",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryProductCart_GroceryProduct_GroceryProductsID",
                table: "GroceryProductCart",
                column: "GroceryProductsID",
                principalTable: "GroceryProduct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
