using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Super.Core.Data.EF.Migrations
{
    public partial class ProductListProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductLists_ProductListId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductListId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductListId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductLists",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductListProduct",
                columns: table => new
                {
                    ProductListId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductListProduct", x => new { x.ProductListId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductListProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductListProduct_ProductLists_ProductListId",
                        column: x => x.ProductListId,
                        principalTable: "ProductLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductListProduct_ProductId",
                table: "ProductListProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductListProduct");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductLists");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductListId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductListId",
                table: "Products",
                column: "ProductListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductLists_ProductListId",
                table: "Products",
                column: "ProductListId",
                principalTable: "ProductLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
