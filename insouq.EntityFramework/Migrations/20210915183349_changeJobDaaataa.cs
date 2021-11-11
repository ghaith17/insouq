using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeJobDaaataa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinWorkExperience",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "JobAds");

            migrationBuilder.RenameColumn(
                name: "WorkExperience",
                table: "JobAds",
                newName: "En_WorkExperience");

            migrationBuilder.RenameColumn(
                name: "CurrentCompany",
                table: "JobAds",
                newName: "En_MinWorkExperience");

            migrationBuilder.AddColumn<string>(
                name: "Ar_MinWorkExperience",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_WorkExperience",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_MinWorkExperience",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_WorkExperience",
                table: "JobAds");

            migrationBuilder.RenameColumn(
                name: "En_WorkExperience",
                table: "JobAds",
                newName: "WorkExperience");

            migrationBuilder.RenameColumn(
                name: "En_MinWorkExperience",
                table: "JobAds",
                newName: "CurrentCompany");

            migrationBuilder.AddColumn<int>(
                name: "MinWorkExperience",
                table: "JobAds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "JobAds",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
