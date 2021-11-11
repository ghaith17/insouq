using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeElectronicAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usage",
                table: "ElectronicAds",
                newName: "En_Usage");

            migrationBuilder.RenameColumn(
                name: "Condition",
                table: "ElectronicAds",
                newName: "En_Condition");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Condition",
                table: "ElectronicAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Usage",
                table: "ElectronicAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_Condition",
                table: "ElectronicAds");

            migrationBuilder.DropColumn(
                name: "Ar_Usage",
                table: "ElectronicAds");

            migrationBuilder.RenameColumn(
                name: "En_Usage",
                table: "ElectronicAds",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "En_Condition",
                table: "ElectronicAds",
                newName: "Condition");
        }
    }
}
