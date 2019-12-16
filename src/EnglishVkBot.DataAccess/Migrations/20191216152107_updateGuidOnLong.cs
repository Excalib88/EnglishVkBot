using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EnglishVkBot.DataAccess.Migrations
{
    public partial class updateGuidOnLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedTexts_LanguageDirections_TargetDirectionId",
                table: "TranslatedTexts");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatedTexts_LanguageDirections_TextDirectionId",
                table: "TranslatedTexts");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedTexts_TargetDirectionId",
                table: "TranslatedTexts");

            migrationBuilder.DropIndex(
                name: "IX_TranslatedTexts_TextDirectionId",
                table: "TranslatedTexts");

            migrationBuilder.DropColumn(
                name: "TargetDirectionId",
                table: "TranslatedTexts");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "TranslatedTexts");

            migrationBuilder.DropColumn(
                name: "TextDirectionId",
                table: "TranslatedTexts");

            migrationBuilder.RenameColumn(
                name: "IsAutoTextRecognition",
                table: "TranslatedTexts",
                newName: "IsActive");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "TranslatedTexts",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "LanguageDirections",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "LanguageDirections",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "LanguageDirections");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "TranslatedTexts",
                newName: "IsAutoTextRecognition");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TranslatedTexts",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "TargetDirectionId",
                table: "TranslatedTexts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "TranslatedTexts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TextDirectionId",
                table: "TranslatedTexts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LanguageDirections",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedTexts_TargetDirectionId",
                table: "TranslatedTexts",
                column: "TargetDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedTexts_TextDirectionId",
                table: "TranslatedTexts",
                column: "TextDirectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedTexts_LanguageDirections_TargetDirectionId",
                table: "TranslatedTexts",
                column: "TargetDirectionId",
                principalTable: "LanguageDirections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatedTexts_LanguageDirections_TextDirectionId",
                table: "TranslatedTexts",
                column: "TextDirectionId",
                principalTable: "LanguageDirections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
