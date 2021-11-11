using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeDlCompanySize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLCompanySizes");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLCompanySizes",
                newName: "Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLCompanySizes",
                newName: "En_Text");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLCompanySizes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
