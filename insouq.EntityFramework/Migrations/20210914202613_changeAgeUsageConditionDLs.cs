using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeAgeUsageConditionDLs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DLAges_Categories_CategoryId",
                table: "DLAges");

            migrationBuilder.DropForeignKey(
                name: "FK_DLConditions_Categories_CategoryId",
                table: "DLConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_DLUsages_Categories_CategoryId",
                table: "DLUsages");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "DLUsages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "DLUsages",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "DLConditions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "DLConditions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "DLAges",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "DLAges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DLUsages_TypeId",
                table: "DLUsages",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DLConditions_TypeId",
                table: "DLConditions",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DLAges_TypeId",
                table: "DLAges",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DLAges_Categories_CategoryId",
                table: "DLAges",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DLAges_Types_TypeId",
                table: "DLAges",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DLConditions_Categories_CategoryId",
                table: "DLConditions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DLConditions_Types_TypeId",
                table: "DLConditions",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DLUsages_Categories_CategoryId",
                table: "DLUsages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DLUsages_Types_TypeId",
                table: "DLUsages",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DLAges_Categories_CategoryId",
                table: "DLAges");

            migrationBuilder.DropForeignKey(
                name: "FK_DLAges_Types_TypeId",
                table: "DLAges");

            migrationBuilder.DropForeignKey(
                name: "FK_DLConditions_Categories_CategoryId",
                table: "DLConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_DLConditions_Types_TypeId",
                table: "DLConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_DLUsages_Categories_CategoryId",
                table: "DLUsages");

            migrationBuilder.DropForeignKey(
                name: "FK_DLUsages_Types_TypeId",
                table: "DLUsages");

            migrationBuilder.DropIndex(
                name: "IX_DLUsages_TypeId",
                table: "DLUsages");

            migrationBuilder.DropIndex(
                name: "IX_DLConditions_TypeId",
                table: "DLConditions");

            migrationBuilder.DropIndex(
                name: "IX_DLAges_TypeId",
                table: "DLAges");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "DLUsages");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "DLConditions");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "DLAges");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "DLUsages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "DLConditions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "DLAges",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_DLUsages_Categories_CategoryId",
                table: "DLUsages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
