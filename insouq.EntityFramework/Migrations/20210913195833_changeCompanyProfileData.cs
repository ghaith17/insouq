using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeCompanyProfileData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Industry",
                table: "CompanyProfiles");

            migrationBuilder.DropColumn(
                name: "ProfileStatus",
                table: "CompanyProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "CompanyProfiles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileStatus",
                table: "CompanyProfiles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
