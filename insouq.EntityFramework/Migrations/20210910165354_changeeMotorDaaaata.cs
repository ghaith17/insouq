using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeeMotorDaaaata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doors",
                table: "MotorAds");

            migrationBuilder.RenameColumn(
                name: "Wheels",
                table: "MotorAds",
                newName: "En_Wheels");

            migrationBuilder.RenameColumn(
                name: "NoOfCylinders",
                table: "MotorAds",
                newName: "En_NoOfCylinders");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "MotorAds",
                newName: "En_Length");

            migrationBuilder.RenameColumn(
                name: "Horsepower",
                table: "MotorAds",
                newName: "En_Horsepower");

            migrationBuilder.RenameColumn(
                name: "EngineSize",
                table: "MotorAds",
                newName: "En_EngineSize");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "MotorAds",
                newName: "En_Doors");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "MotorAds",
                newName: "En_Capacity");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Age",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Capacity",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Doors",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_EngineSize",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Horsepower",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Length",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_NoOfCylinders",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Wheels",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "En_Age",
                table: "MotorAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_Age",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "Ar_Capacity",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "Ar_Doors",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "Ar_EngineSize",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "Ar_Horsepower",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "Ar_Length",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "Ar_NoOfCylinders",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "Ar_Wheels",
                table: "MotorAds");

            migrationBuilder.DropColumn(
                name: "En_Age",
                table: "MotorAds");

            migrationBuilder.RenameColumn(
                name: "En_Wheels",
                table: "MotorAds",
                newName: "Wheels");

            migrationBuilder.RenameColumn(
                name: "En_NoOfCylinders",
                table: "MotorAds",
                newName: "NoOfCylinders");

            migrationBuilder.RenameColumn(
                name: "En_Length",
                table: "MotorAds",
                newName: "Length");

            migrationBuilder.RenameColumn(
                name: "En_Horsepower",
                table: "MotorAds",
                newName: "Horsepower");

            migrationBuilder.RenameColumn(
                name: "En_EngineSize",
                table: "MotorAds",
                newName: "EngineSize");

            migrationBuilder.RenameColumn(
                name: "En_Doors",
                table: "MotorAds",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "En_Capacity",
                table: "MotorAds",
                newName: "Age");

            migrationBuilder.AddColumn<int>(
                name: "Doors",
                table: "MotorAds",
                type: "int",
                nullable: true);
        }
    }
}
