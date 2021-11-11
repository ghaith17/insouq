using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class addNumberPlanDL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_CurrentNetwork",
                table: "NumberAds");

            migrationBuilder.DropColumn(
                name: "Ar_MobileNumberType",
                table: "NumberAds");

            migrationBuilder.RenameColumn(
                name: "En_MobileNumberType",
                table: "NumberAds",
                newName: "En_MobileNumberPlan");

            migrationBuilder.RenameColumn(
                name: "En_CurrentNetwork",
                table: "NumberAds",
                newName: "Ar_MobileNumberPlan");

            migrationBuilder.CreateTable(
                name: "DLNumberPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLNumberPlans", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DLNumberPlans");

            migrationBuilder.RenameColumn(
                name: "En_MobileNumberPlan",
                table: "NumberAds",
                newName: "En_MobileNumberType");

            migrationBuilder.RenameColumn(
                name: "Ar_MobileNumberPlan",
                table: "NumberAds",
                newName: "En_CurrentNetwork");

            migrationBuilder.AddColumn<string>(
                name: "Ar_CurrentNetwork",
                table: "NumberAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_MobileNumberType",
                table: "NumberAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
