using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeDLWorkExp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLWorkExperiences",
                newName: "En_Text");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLWorkExperiences",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLWorkExperiences");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLWorkExperiences",
                newName: "Value");
        }
    }
}
