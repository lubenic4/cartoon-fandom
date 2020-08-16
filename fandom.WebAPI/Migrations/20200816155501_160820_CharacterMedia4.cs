using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fandom.WebAPI.Migrations
{
    public partial class _160820_CharacterMedia4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Characters_CharacterId",
                table: "MediaFile");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFile_Characters_CharacterId1",
                table: "MediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFile_CharacterId",
                table: "MediaFile");

            migrationBuilder.DropIndex(
                name: "IX_MediaFile_CharacterId1",
                table: "MediaFile");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "MediaFile");

            migrationBuilder.DropColumn(
                name: "CharacterId1",
                table: "MediaFile");

            migrationBuilder.CreateTable(
                name: "CharacterMediaFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Thumbnail = table.Column<byte[]>(nullable: true),
                    CharacterId = table.Column<int>(nullable: false),
                    CharacterId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMediaFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterMediaFile_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMediaFile_Characters_CharacterId1",
                        column: x => x.CharacterId1,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMediaFile_CharacterId",
                table: "CharacterMediaFile",
                column: "CharacterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMediaFile_CharacterId1",
                table: "CharacterMediaFile",
                column: "CharacterId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMediaFile");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "MediaFile",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterId1",
                table: "MediaFile",
                type: "int",
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
        }
    }
}
