using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeDLMobileNumberCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DLMobileNumberCodes_DLOperators_OperatorId",
                table: "DLMobileNumberCodes");

            migrationBuilder.DropColumn(
                name: "OpeatorId",
                table: "DLMobileNumberCodes");

            migrationBuilder.AlterColumn<int>(
                name: "OperatorId",
                table: "DLMobileNumberCodes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DLMobileNumberCodes_DLOperators_OperatorId",
                table: "DLMobileNumberCodes",
                column: "OperatorId",
                principalTable: "DLOperators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DLMobileNumberCodes_DLOperators_OperatorId",
                table: "DLMobileNumberCodes");

            migrationBuilder.AlterColumn<int>(
                name: "OperatorId",
                table: "DLMobileNumberCodes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OpeatorId",
                table: "DLMobileNumberCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DLMobileNumberCodes_DLOperators_OperatorId",
                table: "DLMobileNumberCodes",
                column: "OperatorId",
                principalTable: "DLOperators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
