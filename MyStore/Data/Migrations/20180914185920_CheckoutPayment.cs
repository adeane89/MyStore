using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyStore.Data.Migrations
{
    public partial class CheckoutPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsID",
                table: "GroceryCartProducts");

            migrationBuilder.DropIndex(
                name: "IX_GroceryCartProducts_GroceryProductsID",
                table: "GroceryCartProducts");

            migrationBuilder.DropColumn(
                name: "GroceryProductsID",
                table: "GroceryCartProducts");

            migrationBuilder.CreateTable(
                name: "GroceryOrders",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AptSuite = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryOrders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GroceryOrderProducts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    GroceryOrderID = table.Column<Guid>(nullable: false),
                    ProductDescription = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryOrderProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GroceryOrderProducts_GroceryOrders_GroceryOrderID",
                        column: x => x.GroceryOrderID,
                        principalTable: "GroceryOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroceryCartProducts_GroceryProductID",
                table: "GroceryCartProducts",
                column: "GroceryProductID");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryOrderProducts_GroceryOrderID",
                table: "GroceryOrderProducts",
                column: "GroceryOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductID",
                table: "GroceryCartProducts",
                column: "GroceryProductID",
                principalTable: "GroceryProduct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductID",
                table: "GroceryCartProducts");

            migrationBuilder.DropTable(
                name: "GroceryOrderProducts");

            migrationBuilder.DropTable(
                name: "GroceryOrders");

            migrationBuilder.DropIndex(
                name: "IX_GroceryCartProducts_GroceryProductID",
                table: "GroceryCartProducts");

            migrationBuilder.AddColumn<int>(
                name: "GroceryProductsID",
                table: "GroceryCartProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryCartProducts_GroceryProductsID",
                table: "GroceryCartProducts",
                column: "GroceryProductsID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsID",
                table: "GroceryCartProducts",
                column: "GroceryProductsID",
                principalTable: "GroceryProduct",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
