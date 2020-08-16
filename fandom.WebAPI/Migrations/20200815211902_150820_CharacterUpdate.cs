using Microsoft.EntityFrameworkCore.Migrations;

namespace fandom.WebAPI.Migrations
{
    public partial class _150820_CharacterUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "MediaFile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MediaFile_CharacterId",
                table: "MediaFile",
                column: "CharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFile_Characters_CharacterId",
                table: "MediaFile",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Characters_CharacterId",
                table: "MediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFile_CharacterId",
                table: "MediaFile");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "MediaFile");
        }
    }
}
