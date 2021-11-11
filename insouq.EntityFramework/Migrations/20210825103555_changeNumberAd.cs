using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeNumberAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlateType",
                table: "NumberAds",
                newName: "En_PlateType");

            migrationBuilder.RenameColumn(
                name: "Operator",
                table: "NumberAds",
                newName: "En_Operator");

            migrationBuilder.RenameColumn(
                name: "Emirate",
                table: "NumberAds",
                newName: "En_Emirate");

            migrationBuilder.RenameColumn(
                name: "Design",
                table: "NumberAds",
                newName: "En_Design");

            migrationBuilder.RenameColumn(
                name: "CurrentNetwork",
                table: "NumberAds",
                newName: "En_CurrentNetwork");

            migrationBuilder.AddColumn<string>(
                name: "Ar_CurrentNetwork",
                table: "NumberAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Design",
                table: "NumberAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Emirate",
                table: "NumberAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Operator",
                table: "NumberAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_PlateType",
                table: "NumberAds",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_CurrentNetwork",
                table: "NumberAds");

            migrationBuilder.DropColumn(
                name: "Ar_Design",
                table: "NumberAds");

            migrationBuilder.DropColumn(
                name: "Ar_Emirate",
                table: "NumberAds");

            migrationBuilder.DropColumn(
                name: "Ar_Operator",
                table: "NumberAds");

            migrationBuilder.DropColumn(
                name: "Ar_PlateType",
                table: "NumberAds");

            migrationBuilder.RenameColumn(
                name: "En_PlateType",
                table: "NumberAds",
                newName: "PlateType");

            migrationBuilder.RenameColumn(
                name: "En_Operator",
                table: "NumberAds",
                newName: "Operator");

            migrationBuilder.RenameColumn(
                name: "En_Emirate",
                table: "NumberAds",
                newName: "Emirate");

            migrationBuilder.RenameColumn(
                name: "En_Design",
                table: "NumberAds",
                newName: "Design");

            migrationBuilder.RenameColumn(
                name: "En_CurrentNetwork",
                table: "NumberAds",
                newName: "CurrentNetwork");
        }
    }
}
