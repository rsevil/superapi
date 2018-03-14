using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Super.Core.Data.EF.Migrations
{
    public partial class UpdateModel_LatitudeLongitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Stores",
                nullable: false,
                type: "decimal(9,6)",
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Stores",
                nullable: false,
                type: "decimal(9,6)",
                oldClrType: typeof(decimal),
                oldType: "decimal(9,6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Stores",
                type: "decimal(9,6)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Stores",
                type: "decimal(9,6)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
