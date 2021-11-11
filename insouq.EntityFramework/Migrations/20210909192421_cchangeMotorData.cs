using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class cchangeMotorData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ar_SteeringSide",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "En_SteeringSide",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherSubCategory",
                table: "MotorAds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "MotorAds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotorAds_SubCategoryId",
                table: "MotorAds",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotorAds_SubCategories_SubCategoryId",
                table: "MotorAds",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotorAds_SubCategories_SubCategoryId",
                table: "MotorAds");

            migrationBuilder.DropIndex(
                name: "IX_MotorAds_SubCategoryId",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "Ar_SteeringSide",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "En_SteeringSide",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "OtherSubCategory",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "MotorAds");
        }
    }
}
