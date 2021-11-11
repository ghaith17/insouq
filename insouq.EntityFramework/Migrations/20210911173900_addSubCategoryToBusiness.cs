using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class addSubCategoryToBusiness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "BussinesAds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BussinesAds_SubCategoryId",
                table: "BussinesAds",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BussinesAds_SubCategories_SubCategoryId",
                table: "BussinesAds",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BussinesAds_SubCategories_SubCategoryId",
                table: "BussinesAds");

            migrationBuilder.DropIndex(
                name: "IX_BussinesAds_SubCategoryId",
                table: "BussinesAds");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "BussinesAds");
        }
    }
}
