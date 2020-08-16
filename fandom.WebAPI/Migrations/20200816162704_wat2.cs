using Microsoft.EntityFrameworkCore.Migrations;

namespace fandom.WebAPI.Migrations
{
    public partial class wat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMediaFile_Characters_CharacterId1",
                table: "CharacterMediaFile");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Episodes_EpisodeId1",
                table: "MediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFile_EpisodeId1",
                table: "MediaFile");

            migrationBuilder.DropIndex(
                name: "IX_CharacterMediaFile_CharacterId1",
                table: "CharacterMediaFile");

            migrationBuilder.DropColumn(
                name: "EpisodeId1",
                table: "MediaFile");

            migrationBuilder.DropColumn(
                name: "CharacterId1",
                table: "CharacterMediaFile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EpisodeId1",
                table: "MediaFile",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId1",
                table: "CharacterMediaFile",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaFile_EpisodeId1",
                table: "MediaFile",
                column: "EpisodeId1");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMediaFile_CharacterId1",
                table: "CharacterMediaFile",
                column: "CharacterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMediaFile_Characters_CharacterId1",
                table: "CharacterMediaFile",
                column: "CharacterId1",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFile_Episodes_EpisodeId1",
                table: "MediaFile",
                column: "EpisodeId1",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
