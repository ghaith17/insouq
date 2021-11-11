using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class addEnAndArLocationToAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Ads",
                newName: "En_Location");

            migrationBuilder.AddColumn<string>(
                name: "Ar_Location",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ar_Location",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "En_Location",
                table: "Ads",
                newName: "Location");
        }
    }
}
