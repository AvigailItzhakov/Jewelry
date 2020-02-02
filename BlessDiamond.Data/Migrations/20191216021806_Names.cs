using Microsoft.EntityFrameworkCore.Migrations;

namespace BlessDiamond.Data.Migrations
{
    public partial class Names : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Buyers",
                newName: "BuyerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BuyerName",
                table: "Buyers",
                newName: "Name");
        }
    }
}
