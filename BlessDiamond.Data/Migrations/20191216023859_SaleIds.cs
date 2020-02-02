using Microsoft.EntityFrameworkCore.Migrations;

namespace BlessDiamond.Data.Migrations
{
    public partial class SaleIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "History");

            migrationBuilder.AlterColumn<int>(
                name: "SaleProductId",
                table: "History",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SaleBuyerId",
                table: "History",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SaleProductId",
                table: "History",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SaleBuyerId",
                table: "History",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "History",
                nullable: false,
                defaultValue: 0);
        }
    }
}
