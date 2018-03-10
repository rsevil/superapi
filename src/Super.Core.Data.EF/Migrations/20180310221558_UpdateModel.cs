using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Super.Core.Data.EF.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreChains_StoreChainId",
                table: "Stores");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreChainId",
                table: "Stores",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreChains_StoreChainId",
                table: "Stores",
                column: "StoreChainId",
                principalTable: "StoreChains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreChains_StoreChainId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stores");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreChainId",
                table: "Stores",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreChains_StoreChainId",
                table: "Stores",
                column: "StoreChainId",
                principalTable: "StoreChains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
