using Microsoft.EntityFrameworkCore.Migrations;

namespace insouq.EntityFramework.Migrations
{
    public partial class EditSavedSearchTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedSearch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alert = table.Column<bool>(type: "bit", nullable: false),
                    EmailAlert = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ADCategoryId = table.Column<int>(type: "int", nullable: false),
                    ADTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedSearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedSearch_Categories_ADCategoryId",
                        column: x => x.ADCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavedSearch_Types_ADTypeId",
                        column: x => x.ADTypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavedSearch_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedSearch_ADCategoryId",
                table: "SavedSearch",
                column: "ADCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedSearch_ADTypeId",
                table: "SavedSearch",
                column: "ADTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedSearch_UserId",
                table: "SavedSearch",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedSearch");
        }
    }
}
