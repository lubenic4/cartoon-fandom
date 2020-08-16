using Microsoft.EntityFrameworkCore.Migrations;

namespace fandom.WebAPI.Migrations
{
    public partial class _160820_CharacterMedia3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Characters_CharacterId",
                table: "MediaFile");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Episodes_EpisodeId",
                table: "MediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFile_CharacterId",
                table: "MediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFile_EpisodeId",
                table: "MediaFile");

            migrationBuilder.AlterColumn<int>(
                name: "EpisodeId",
                table: "MediaFile",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "MediaFile",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId1",
                table: "MediaFile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EpisodeId1",
                table: "MediaFile",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaFile_CharacterId",
                table: "MediaFile",
                column: "CharacterId",
                unique: true,
                filter: "[CharacterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFile_CharacterId1",
                table: "MediaFile",
                column: "CharacterId1");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFile_EpisodeId",
                table: "MediaFile",
                column: "EpisodeId",
                unique: true,
                filter: "[EpisodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFile_EpisodeId1",
                table: "MediaFile",
                column: "EpisodeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFile_Characters_CharacterId",
                table: "MediaFile",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFile_Characters_CharacterId1",
                table: "MediaFile",
                column: "CharacterId1",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFile_Episodes_EpisodeId",
                table: "MediaFile",
                column: "EpisodeId",
                principalTable: "Episodes",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Characters_CharacterId",
                table: "MediaFile");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Characters_CharacterId1",
                table: "MediaFile");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Episodes_EpisodeId",
                table: "MediaFile");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Episodes_EpisodeId1",
                table: "MediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFile_CharacterId",
                table: "MediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFile_CharacterId1",
                table: "MediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFile_EpisodeId",
                table: "MediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFile_EpisodeId1",
                table: "MediaFile");

            migrationBuilder.DropColumn(
                name: "CharacterId1",
                table: "MediaFile");

            migrationBuilder.DropColumn(
                name: "EpisodeId1",
                table: "MediaFile");

            migrationBuilder.AlterColumn<int>(
                name: "EpisodeId",
                table: "MediaFile",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "MediaFile",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaFile_CharacterId",
                table: "MediaFile",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaFile_EpisodeId",
                table: "MediaFile",
                column: "EpisodeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFile_Characters_CharacterId",
                table: "MediaFile",
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
