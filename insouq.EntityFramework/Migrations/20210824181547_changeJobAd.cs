using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeJobAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisaStatus",
                table: "JobAds",
                newName: "En_VisaStatus");

            migrationBuilder.RenameColumn(
                name: "NoticePeriod",
                table: "JobAds",
                newName: "En_NoticePeriod");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "JobAds",
                newName: "En_Nationality");

            migrationBuilder.RenameColumn(
                name: "MinEducationLevel",
                table: "JobAds",
                newName: "En_MinEducationLevel");

            migrationBuilder.RenameColumn(
                name: "JobType",
                table: "JobAds",
                newName: "En_JobType");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "JobAds",
                newName: "En_Gender");

            migrationBuilder.RenameColumn(
                name: "EmploymentType",
                table: "JobAds",
                newName: "En_EmploymentType");

            migrationBuilder.RenameColumn(
                name: "EducationLevel",
                table: "JobAds",
                newName: "En_EducationLevel");

            migrationBuilder.RenameColumn(
                name: "CurrentLocation",
                table: "JobAds",
                newName: "En_CurrentLocation");

            migrationBuilder.RenameColumn(
                name: "CompanyIndustry",
                table: "JobAds",
                newName: "En_CompanyIndustry");

            migrationBuilder.RenameColumn(
                name: "Commitment",
                table: "JobAds",
                newName: "En_Commitment");

            migrationBuilder.RenameColumn(
                name: "CareerLevel",
                table: "JobAds",
                newName: "En_CareerLevel");

            migrationBuilder.AddColumn<string>(
                name: "Ar_CareerLevel",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Commitment",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_CompanyIndustry",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_CurrentLocation",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_EducationLevel",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_EmploymentType",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Gender",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_JobType",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_MinEducationLevel",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Nationality",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_NoticePeriod",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_VisaStatus",
                table: "JobAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_CareerLevel",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_Commitment",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_CompanyIndustry",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_CurrentLocation",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_EducationLevel",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_EmploymentType",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_Gender",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_JobType",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_MinEducationLevel",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_Nationality",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_NoticePeriod",
                table: "JobAds");

            migrationBuilder.DropColumn(
                name: "Ar_VisaStatus",
                table: "JobAds");

            migrationBuilder.RenameColumn(
                name: "En_VisaStatus",
                table: "JobAds",
                newName: "VisaStatus");

            migrationBuilder.RenameColumn(
                name: "En_NoticePeriod",
                table: "JobAds",
                newName: "NoticePeriod");

            migrationBuilder.RenameColumn(
                name: "En_Nationality",
                table: "JobAds",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "En_MinEducationLevel",
                table: "JobAds",
                newName: "MinEducationLevel");

            migrationBuilder.RenameColumn(
                name: "En_JobType",
                table: "JobAds",
                newName: "JobType");

            migrationBuilder.RenameColumn(
                name: "En_Gender",
                table: "JobAds",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "En_EmploymentType",
                table: "JobAds",
                newName: "EmploymentType");

            migrationBuilder.RenameColumn(
                name: "En_EducationLevel",
                table: "JobAds",
                newName: "EducationLevel");

            migrationBuilder.RenameColumn(
                name: "En_CurrentLocation",
                table: "JobAds",
                newName: "CurrentLocation");

            migrationBuilder.RenameColumn(
                name: "En_CompanyIndustry",
                table: "JobAds",
                newName: "CompanyIndustry");

            migrationBuilder.RenameColumn(
                name: "En_Commitment",
                table: "JobAds",
                newName: "Commitment");

            migrationBuilder.RenameColumn(
                name: "En_CareerLevel",
                table: "JobAds",
                newName: "CareerLevel");
        }
    }
}
