using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeServiceAdDAAta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarLiftFrom",
                table: "ServiceAds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarLiftTo",
                table: "ServiceAds",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarLiftFrom",
                table: "ServiceAds");

            migrationBuilder.DropColumn(
                name: "CarLiftTo",
                table: "ServiceAds");
        }
    }
}
