using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changePropertyAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RentPaidIn",
                table: "PropertyAds",
                newName: "En_RentPaidIn");

            migrationBuilder.RenameColumn(
                name: "PropertyStatus",
                table: "PropertyAds",
                newName: "En_PropertyStatus");

            migrationBuilder.RenameColumn(
                name: "Furnishing",
                table: "PropertyAds",
                newName: "En_Furnishing");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Furnishing",
                table: "PropertyAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ar_PropertyStatus",
                table: "PropertyAds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_RentPaidIn",
                table: "PropertyAds",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_Furnishing",
                table: "PropertyAds");

            migrationBuilder.DropColumn(
                name: "Ar_PropertyStatus",
                table: "PropertyAds");

            migrationBuilder.DropColumn(
                name: "Ar_RentPaidIn",
                table: "PropertyAds");

            migrationBuilder.RenameColumn(
                name: "En_RentPaidIn",
                table: "PropertyAds",
                newName: "RentPaidIn");

            migrationBuilder.RenameColumn(
                name: "En_PropertyStatus",
                table: "PropertyAds",
                newName: "PropertyStatus");

            migrationBuilder.RenameColumn(
                name: "En_Furnishing",
                table: "PropertyAds",
                newName: "Furnishing");
        }
    }
}
