using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class chnageMotorDLs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLWheels",
                newName: "En_Text");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLNoOfCylinders",
                newName: "En_Text");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLMotorLengths",
                newName: "En_Text");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLLengths",
                newName: "En_Text");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLHorsepowers",
                newName: "En_Text");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLEngineSizes",
                newName: "En_Text");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLDoors",
                newName: "En_Text");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLCapacities",
                newName: "En_Text");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "DLAges",
                newName: "En_Text");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLWheels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLNoOfCylinders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLMotorLengths",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLLengths",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLHorsepowers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLEngineSizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLDoors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLCapacities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLAges",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLWheels");

            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLNoOfCylinders");

            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLMotorLengths");

            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLLengths");

            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLHorsepowers");

            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLEngineSizes");

            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLDoors");

            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLCapacities");

            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLAges");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLWheels",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLNoOfCylinders",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLMotorLengths",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLLengths",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLHorsepowers",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLEngineSizes",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLDoors",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLCapacities",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "En_Text",
                table: "DLAges",
                newName: "Value");
        }
    }
}
