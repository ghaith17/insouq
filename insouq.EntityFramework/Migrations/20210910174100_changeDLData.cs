using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeDLData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DLUsages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DLHorsepowers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DLConditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DLAges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DLUsages_CategoryId",
                table: "DLUsages",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DLHorsepowers_CategoryId",
                table: "DLHorsepowers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DLConditions_CategoryId",
                table: "DLConditions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DLAges_CategoryId",
                table: "DLAges",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DLAges_Categories_CategoryId",
                table: "DLAges",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DLConditions_Categories_CategoryId",
                table: "DLConditions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DLHorsepowers_Categories_CategoryId",
                table: "DLHorsepowers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DLUsages_Categories_CategoryId",
                table: "DLUsages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DLAges_Categories_CategoryId",
                table: "DLAges");

            migrationBuilder.DropForeignKey(
                name: "FK_DLConditions_Categories_CategoryId",
                table: "DLConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_DLHorsepowers_Categories_CategoryId",
                table: "DLHorsepowers");

            migrationBuilder.DropForeignKey(
                name: "FK_DLUsages_Categories_CategoryId",
                table: "DLUsages");

            migrationBuilder.DropIndex(
                name: "IX_DLUsages_CategoryId",
                table: "DLUsages");

            migrationBuilder.DropIndex(
                name: "IX_DLHorsepowers_CategoryId",
                table: "DLHorsepowers");

            migrationBuilder.DropIndex(
                name: "IX_DLConditions_CategoryId",
                table: "DLConditions");

            migrationBuilder.DropIndex(
                name: "IX_DLAges_CategoryId",
                table: "DLAges");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DLUsages");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DLHorsepowers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DLConditions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "DLAges");
        }
    }
}
