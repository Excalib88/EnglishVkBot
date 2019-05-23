using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EnglishVkBot.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguageDirections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Direction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageDirections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslatedTexts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Text = table.Column<string>(nullable: true),
                    TextDirectionId = table.Column<int>(nullable: false),
                    TargetDirectionId = table.Column<int>(nullable: false),
                    IsAutoTextRecognition = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslatedTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslatedTexts_LanguageDirections_TargetDirectionId",
                        column: x => x.TargetDirectionId,
                        principalTable: "LanguageDirections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslatedTexts_LanguageDirections_TextDirectionId",
                        column: x => x.TextDirectionId,
                        principalTable: "LanguageDirections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedTexts_TargetDirectionId",
                table: "TranslatedTexts",
                column: "TargetDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedTexts_TextDirectionId",
                table: "TranslatedTexts",
                column: "TextDirectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslatedTexts");

            migrationBuilder.DropTable(
                name: "LanguageDirections");
        }
    }
}
