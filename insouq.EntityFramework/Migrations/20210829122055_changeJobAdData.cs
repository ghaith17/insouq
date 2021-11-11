using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeJobAdData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_CompanyIndustry",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Benefits",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "CVRequired",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "CompanySize",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "En_CompanyIndustry",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "HideCompanyDetails",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "MonthlySalary",
                table: "JobAds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ar_CompanyIndustry",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Benefits",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CVRequired",
                table: "JobAds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CompanySize",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "En_CompanyIndustry",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HideCompanyDetails",
                table: "JobAds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "MonthlySalary",
                table: "JobAds",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
