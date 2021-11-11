using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class addFinalDriveSystemDLAndSellerTypeDL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DLFinalDriveSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLFinalDriveSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DLSellerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ar_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DLSellerTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DLFinalDriveSystems");

            migrationBuilder.DropTable(
                name: "DLSellerTypes");
        }
    }
}
