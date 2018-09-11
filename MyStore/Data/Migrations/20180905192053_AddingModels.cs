using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyStore.Data.Migrations
{
    public partial class AddingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<int>(
                name: "GroceryCartID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true, defaultValueSql: "GetDate()"),
                    DateLastModified = table.Column<DateTime>(nullable: true, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "GroceryProduct",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GroceryCategoryName = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryProduct", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GroceryProduct_Categories_Name",
                        column: x => x.Name,
                        principalTable: "Categories",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroceryProductCart",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserID = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    GroceryProductsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryProductCart", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GroceryProductCart_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroceryProductCart_GroceryProduct_GroceryProductsID",
                        column: x => x.GroceryProductsID,
                        principalTable: "GroceryProduct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroceryCartProducts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    GroceryCartID = table.Column<int>(nullable: false),
                    GroceryProductsID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryCartProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GroceryCartProducts_GroceryProductCart_GroceryCartID",
                        column: x => x.GroceryCartID,
                        principalTable: "GroceryProductCart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroceryCartProducts_GroceryProduct_GroceryProductsID",
                        column: x => x.GroceryProductsID,
                        principalTable: "GroceryProduct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryCartProducts_GroceryCartID",
                table: "GroceryCartProducts",
                column: "GroceryCartID");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryCartProducts_GroceryProductsID",
                table: "GroceryCartProducts",
                column: "GroceryProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProduct_Name",
                table: "GroceryProduct",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProductCart_ApplicationUserID",
                table: "GroceryProductCart",
                column: "ApplicationUserID",
                unique: true,
                filter: "[ApplicationUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryProductCart_GroceryProductsID",
                table: "GroceryProductCart",
                column: "GroceryProductsID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GroceryCartProducts");

            migrationBuilder.DropTable(
                name: "GroceryProductCart");

            migrationBuilder.DropTable(
                name: "GroceryProduct");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "GroceryCartID",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
