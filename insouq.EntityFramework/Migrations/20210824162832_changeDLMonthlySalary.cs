using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeDLMonthlySalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLMonthlySalaries");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLMonthlySalaries",
                newName: "Value");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLMonthlySalaries",
                newName: "En_Text");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLMonthlySalaries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
