using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class EditNotificationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "En_Emirate",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "En_PlateType",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlateCode",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CategoryId",
                table: "Notifications",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Categories_CategoryId",
                table: "Notifications",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Categories_CategoryId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_CategoryId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "En_Emirate",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "En_PlateType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PlateCode",
                table: "Notifications");
        }
    }
}
