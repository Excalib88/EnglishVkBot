using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace EnglishVkBot.DataAccess
{
    public partial class Init: Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("LanguageDirections");
        }
    }
}