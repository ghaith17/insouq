using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class AddMessageToNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromValue",
                table: "DLAdvertisingBudjets");

            migrationBuilder.DropColumn(
                name: "ToValue",
                table: "DLAdvertisingBudjets");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ar_Text",
                table: "DLAdvertisingBudjets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "En_Text",
                table: "DLAdvertisingBudjets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUsText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUsArText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisingReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    En_Title1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Title1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Description1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Description1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Title2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Title2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Description2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Description2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Title3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Title3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Description3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Description3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisingReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisorImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisorImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    En_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FQAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FQAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HIW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paragraph1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paragraph2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paragraph3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_paragraph1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_paragraph2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_paragraph3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VIDUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img1Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img2Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HIW", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SMEs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    En_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ar_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    En_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMEs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "AdvertisingReasons");

            migrationBuilder.DropTable(
                name: "AdvertisorImages");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "FQAS");

            migrationBuilder.DropTable(
                name: "HIW");

            migrationBuilder.DropTable(
                name: "SMEs");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Ar_Text",
                table: "DLAdvertisingBudjets");

            migrationBuilder.DropColumn(
                name: "En_Text",
                table: "DLAdvertisingBudjets");

            migrationBuilder.AddColumn<double>(
                name: "FromValue",
                table: "DLAdvertisingBudjets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ToValue",
                table: "DLAdvertisingBudjets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
