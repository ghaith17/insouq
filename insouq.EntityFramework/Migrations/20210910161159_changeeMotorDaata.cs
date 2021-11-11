using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeeMotorDaata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ar_PartName",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "En_PartName",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_PartName",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "En_PartName",
                table: "MotorAds");
        }
    }
}
