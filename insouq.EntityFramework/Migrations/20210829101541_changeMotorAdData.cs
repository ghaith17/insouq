using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeMotorAdData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotorAds_SubCategories_SubCategoryId",
                table: "MotorAds");

            migrationBuilder.DropForeignKey(
                name: "FK_MotorAds_SubTypes_SubTypeId",
                table: "MotorAds");

            migrationBuilder.DropIndex(
                name: "IX_MotorAds_SubCategoryId",
                table: "MotorAds");

            migrationBuilder.DropIndex(
                name: "IX_MotorAds_SubTypeId",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "OtherSubCategory",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "OtherSubType",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "SubTypeId",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "VIN",
                table: "MotorAds");

            migrationBuilder.AddColumn<string>(
                name: "Ar_FinalDriveSystem",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_SellerType",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "En_FinalDriveSystem",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "En_SellerType",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_FinalDriveSystem",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "Ar_SellerType",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "En_FinalDriveSystem",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "En_SellerType",
                table: "MotorAds");

            migrationBuilder.AddColumn<string>(
                name: "OtherSubCategory",
                table: "MotorAds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherSubType",
                table: "MotorAds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "MotorAds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubTypeId",
                table: "MotorAds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "MotorAds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotorAds_SubCategoryId",
                table: "MotorAds",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorAds_SubTypeId",
                table: "MotorAds",
                column: "SubTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotorAds_SubCategories_SubCategoryId",
                table: "MotorAds",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MotorAds_SubTypes_SubTypeId",
                table: "MotorAds",
                column: "SubTypeId",
                principalTable: "SubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
