using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlessDiamond.Data.Migrations
{
    public partial class DateOfSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfSale",
                table: "Sales",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfSale",
                table: "Sales");
        }
    }
}
