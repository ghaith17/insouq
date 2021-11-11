using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeMakerDLL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DLMotorMakers_Categories_CategoryId",
                table: "DLMotorMakers");

            migrationBuilder.DropIndex(
                name: "IX_DLMotorMakers_CategoryId",
                table: "DLMotorMakers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DLMotorMakers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DLMotorMakers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DLMotorMakers_CategoryId",
                table: "DLMotorMakers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DLMotorMakers_Categories_CategoryId",
                table: "DLMotorMakers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
