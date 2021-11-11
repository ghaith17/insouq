using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeDLPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DLParts_SubCategories_SubCategoryId",
                table: "DLParts");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "DLParts",
                newName: "SubTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DLParts_SubCategoryId",
                table: "DLParts",
                newName: "IX_DLParts_SubTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DLParts_SubTypes_SubTypeId",
                table: "DLParts",
                column: "SubTypeId",
                principalTable: "SubTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DLParts_SubTypes_SubTypeId",
                table: "DLParts");

            migrationBuilder.RenameColumn(
                name: "SubTypeId",
                table: "DLParts",
                newName: "SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_DLParts_SubTypeId",
                table: "DLParts",
                newName: "IX_DLParts_SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DLParts_SubCategories_SubCategoryId",
                table: "DLParts",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
