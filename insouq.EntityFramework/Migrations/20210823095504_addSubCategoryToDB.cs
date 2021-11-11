using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class addSubCategoryToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassifiedAds_SubCategory_SubCategoryId",
                table: "ClassifiedAds");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicAds_SubCategory_SubCategoryId",
                table: "ElectronicAds");

            migrationBuilder.DropForeignKey(
                name: "FK_MotorAds_SubCategory_SubCategoryId",
                table: "MotorAds");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyAds_SubCategory_SubCategoryId",
                table: "PropertyAds");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAds_SubCategory_SubCategoryId",
                table: "ServiceAds");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Categories_CategoryId",
                table: "SubCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SubType_SubCategory_SubCategoryId",
                table: "SubType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory");

            migrationBuilder.RenameTable(
                name: "SubCategory",
                newName: "SubCategories");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategories",
                newName: "IX_SubCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassifiedAds_SubCategories_SubCategoryId",
                table: "ClassifiedAds",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicAds_SubCategories_SubCategoryId",
                table: "ElectronicAds",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MotorAds_SubCategories_SubCategoryId",
                table: "MotorAds",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyAds_SubCategories_SubCategoryId",
                table: "PropertyAds",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAds_SubCategories_SubCategoryId",
                table: "ServiceAds",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubType_SubCategories_SubCategoryId",
                table: "SubType",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassifiedAds_SubCategories_SubCategoryId",
                table: "ClassifiedAds");

            migrationBuilder.DropForeignKey(
                name: "FK_ElectronicAds_SubCategories_SubCategoryId",
                table: "ElectronicAds");

            migrationBuilder.DropForeignKey(
                name: "FK_MotorAds_SubCategories_SubCategoryId",
                table: "MotorAds");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyAds_SubCategories_SubCategoryId",
                table: "PropertyAds");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAds_SubCategories_SubCategoryId",
                table: "ServiceAds");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SubType_SubCategories_SubCategoryId",
                table: "SubType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                newName: "SubCategory");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategory",
                newName: "IX_SubCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategory",
                table: "SubCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassifiedAds_SubCategory_SubCategoryId",
                table: "ClassifiedAds",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ElectronicAds_SubCategory_SubCategoryId",
                table: "ElectronicAds",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MotorAds_SubCategory_SubCategoryId",
                table: "MotorAds",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyAds_SubCategory_SubCategoryId",
                table: "PropertyAds",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAds_SubCategory_SubCategoryId",
                table: "ServiceAds",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Categories_CategoryId",
                table: "SubCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubType_SubCategory_SubCategoryId",
                table: "SubType",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
