using Microsoft.EntityFrameworkCore.Migrations;

namespace fandom.WebAPI.Migrations
{
    public partial class _2408_CharactersEpisodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMainCharacter",
                table: "EpisodeCharacters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainCharacter",
                table: "EpisodeCharacters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
