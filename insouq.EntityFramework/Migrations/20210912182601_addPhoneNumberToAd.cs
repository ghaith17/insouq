using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class addPhoneNumberToAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Ads");
        }
    }
}
