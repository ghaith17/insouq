using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeMotorDaaaata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherSubType",
                table: "MotorAds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubTypeId",
                table: "MotorAds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotorAds_SubTypeId",
                table: "MotorAds",
                column: "SubTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotorAds_SubTypes_SubTypeId",
                table: "MotorAds",
                column: "SubTypeId",
                principalTable: "SubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotorAds_SubTypes_SubTypeId",
                table: "MotorAds");

            migrationBuilder.DropIndex(
                name: "IX_MotorAds_SubTypeId",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "OtherSubType",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "SubTypeId",
                table: "MotorAds");
        }
    }
}
