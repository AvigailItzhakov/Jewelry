using Microsoft.EntityFrameworkCore.Migrations;

namespace BlessDiamond.Data.Migrations
{
    public partial class intSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PhoneNumber",
                table: "Buyers",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Buyers",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
