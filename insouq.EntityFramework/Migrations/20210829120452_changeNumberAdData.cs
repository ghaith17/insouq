using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class changeNumberAdData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "En_Design",
                table: "NumberAds",
                newName: "En_MobileNumberType");

            migrationBuilder.RenameColumn(
                name: "Ar_Design",
                table: "NumberAds",
                newName: "Ar_MobileNumberType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "En_MobileNumberType",
                table: "NumberAds",
                newName: "En_Design");

            migrationBuilder.RenameColumn(
                name: "Ar_MobileNumberType",
                table: "NumberAds",
                newName: "Ar_Design");
        }
    }
}
