using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class removeMakerFromDLEngineSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DLEngineSizes_DLMotorMakers_MakerId",
                table: "DLEngineSizes");

            migrationBuilder.DropIndex(
                name: "IX_DLEngineSizes_MakerId",
                table: "DLEngineSizes");

            migrationBuilder.DropColumn(
                name: "MakerId",
                table: "DLEngineSizes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MakerId",
                table: "DLEngineSizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DLEngineSizes_MakerId",
                table: "DLEngineSizes",
                column: "MakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DLEngineSizes_DLMotorMakers_MakerId",
                table: "DLEngineSizes",
                column: "MakerId",
                principalTable: "DLMotorMakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
