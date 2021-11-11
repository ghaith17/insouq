using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeElectonicsDaaata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "En_Condition",
                table: "ElectronicAds",
                newName: "En_Color");

            migrationBuilder.RenameColumn(
                name: "Ar_Condition",
                table: "ElectronicAds",
                newName: "En_Age");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "ElectronicAds",
                newName: "Ar_Color");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Age",
                table: "ElectronicAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_Age",
                table: "ElectronicAds");

            migrationBuilder.RenameColumn(
                name: "En_Color",
                table: "ElectronicAds",
                newName: "En_Condition");

            migrationBuilder.RenameColumn(
                name: "En_Age",
                table: "ElectronicAds",
                newName: "Ar_Condition");

            migrationBuilder.RenameColumn(
                name: "Ar_Color",
                table: "ElectronicAds",
                newName: "Age");
        }
    }
}
