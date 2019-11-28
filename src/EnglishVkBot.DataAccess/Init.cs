using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace EnglishVkBot.DataAccess
{
    public class Init: Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name:"LanguageDirections", 
                columns:table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(),
                    Directon = table.Column<string>()
                },
                constraints: table => { table.PrimaryKey("PK_LanguageDirections", x => x.Id); });
            
            migrationBuilder.CreateTable(
                name:"TranslatedTexts", 
                columns:table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Text = table.Column<string>(),
                    TextDirectionId = table.Column<int>(),
                    TargetDirectionId = table.Column<int>(),
                    IsAutoTextRecognitions = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslatedTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslatedTexts_LanguageDirections_TextDirectionId",
                        column: x => x.TextDirectionId,
                        principalTable: "LanguageDirections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    
                    table.ForeignKey(
                        name: "FK_TranslatedTexts_LanguageDirections_TargetDirectionId",
                        column: x => x.TargetDirectionId,
                        principalTable: "LanguageDirections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("LanguageDirections");
            migrationBuilder.DropTable("TranslatedTexts");
        }
    }
}