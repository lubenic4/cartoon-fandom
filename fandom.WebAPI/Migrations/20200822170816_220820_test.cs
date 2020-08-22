using Microsoft.EntityFrameworkCore.Migrations;

namespace fandom.WebAPI.Migrations
{
    public partial class _220820_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMediaFile_Characters_CharacterId",
                table: "CharacterMediaFile");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Episodes_EpisodeId",
                table: "MediaFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaFile",
                table: "MediaFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterMediaFile",
                table: "CharacterMediaFile");

            migrationBuilder.RenameTable(
                name: "MediaFile",
                newName: "MediaFiles");

            migrationBuilder.RenameTable(
                name: "CharacterMediaFile",
                newName: "CharacterMediaFiles");

            migrationBuilder.RenameIndex(
                name: "IX_MediaFile_EpisodeId",
                table: "MediaFiles",
                newName: "IX_MediaFiles_EpisodeId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMediaFile_CharacterId",
                table: "CharacterMediaFiles",
                newName: "IX_CharacterMediaFiles_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaFiles",
                table: "MediaFiles",
                column: "MediaFileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterMediaFiles",
                table: "CharacterMediaFiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMediaFiles_Characters_CharacterId",
                table: "CharacterMediaFiles",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Episodes_EpisodeId",
                table: "MediaFiles",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterMediaFiles_Characters_CharacterId",
                table: "CharacterMediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Episodes_EpisodeId",
                table: "MediaFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaFiles",
                table: "MediaFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CharacterMediaFiles",
                table: "CharacterMediaFiles");

            migrationBuilder.RenameTable(
                name: "MediaFiles",
                newName: "MediaFile");

            migrationBuilder.RenameTable(
                name: "CharacterMediaFiles",
                newName: "CharacterMediaFile");

            migrationBuilder.RenameIndex(
                name: "IX_MediaFiles_EpisodeId",
                table: "MediaFile",
                newName: "IX_MediaFile_EpisodeId");

            migrationBuilder.RenameIndex(
                name: "IX_CharacterMediaFiles_CharacterId",
                table: "CharacterMediaFile",
                newName: "IX_CharacterMediaFile_CharacterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaFile",
                table: "MediaFile",
                column: "MediaFileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CharacterMediaFile",
                table: "CharacterMediaFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterMediaFile_Characters_CharacterId",
                table: "CharacterMediaFile",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFile_Episodes_EpisodeId",
                table: "MediaFile",
                column: "EpisodeId",
                principalTable: "Episodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
