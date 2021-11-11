using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeClassifiedAdData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "ClassifiedAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Condition",
                table: "ClassifiedAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Usage",
                table: "ClassifiedAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "En_Condition",
                table: "ClassifiedAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "En_Usage",
                table: "ClassifiedAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Warranty",
                table: "ClassifiedAds",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "ClassifiedAds");

            migrationBuilder.DropColumn(
                name: "Ar_Condition",
                table: "ClassifiedAds");

            migrationBuilder.DropColumn(
                name: "Ar_Usage",
                table: "ClassifiedAds");

            migrationBuilder.DropColumn(
                name: "En_Condition",
                table: "ClassifiedAds");

            migrationBuilder.DropColumn(
                name: "En_Usage",
                table: "ClassifiedAds");

            migrationBuilder.DropColumn(
                name: "Warranty",
                table: "ClassifiedAds");
        }
    }
}
