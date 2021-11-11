using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class addSubTypeToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassifiedAds_SubType_SubTypeId",
                table: "ClassifiedAds");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicAds_SubType_SubTypeId",
                table: "ElectronicAds");

            migrationBuilder.DropForeignKey(
                name: "FK_MotorAds_SubType_SubTypeId",
                table: "MotorAds");

            migrationBuilder.DropForeignKey(
                name: "FK_SubType_SubCategories_SubCategoryId",
                table: "SubType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubType",
                table: "SubType");

            migrationBuilder.RenameTable(
                name: "SubType",
                newName: "SubTypes");

            migrationBuilder.RenameIndex(
                name: "IX_SubType_SubCategoryId",
                table: "SubTypes",
                newName: "IX_SubTypes_SubCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubTypes",
                table: "SubTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassifiedAds_SubTypes_SubTypeId",
                table: "ClassifiedAds",
                column: "SubTypeId",
                principalTable: "SubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicAds_SubTypes_SubTypeId",
                table: "ElectronicAds",
                column: "SubTypeId",
                principalTable: "SubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MotorAds_SubTypes_SubTypeId",
                table: "MotorAds",
                column: "SubTypeId",
                principalTable: "SubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubTypes_SubCategories_SubCategoryId",
                table: "SubTypes",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassifiedAds_SubTypes_SubTypeId",
                table: "ClassifiedAds");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicAds_SubTypes_SubTypeId",
                table: "ElectronicAds");

            migrationBuilder.DropForeignKey(
                name: "FK_MotorAds_SubTypes_SubTypeId",
                table: "MotorAds");

            migrationBuilder.DropForeignKey(
                name: "FK_SubTypes_SubCategories_SubCategoryId",
                table: "SubTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubTypes",
                table: "SubTypes");

            migrationBuilder.RenameTable(
                name: "SubTypes",
                newName: "SubType");

            migrationBuilder.RenameIndex(
                name: "IX_SubTypes_SubCategoryId",
                table: "SubType",
                newName: "IX_SubType_SubCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubType",
                table: "SubType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassifiedAds_SubType_SubTypeId",
                table: "ClassifiedAds",
                column: "SubTypeId",
                principalTable: "SubType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicAds_SubType_SubTypeId",
                table: "ElectronicAds",
                column: "SubTypeId",
                principalTable: "SubType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MotorAds_SubType_SubTypeId",
                table: "MotorAds",
                column: "SubTypeId",
                principalTable: "SubType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubType_SubCategories_SubCategoryId",
                table: "SubType",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
