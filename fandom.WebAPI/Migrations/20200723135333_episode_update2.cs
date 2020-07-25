using Microsoft.EntityFrameworkCore.Migrations;

namespace fandom.WebAPI.Migrations
{
    public partial class episode_update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfSeason",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "OrdinalNumber",
                table: "Episodes");

            migrationBuilder.AddColumn<int>(
                name: "OverallNumberOfEpisode",
                table: "Episodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeasonEpisodeNumber",
                table: "Episodes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverallNumberOfEpisode",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "SeasonEpisodeNumber",
                table: "Episodes");

            migrationBuilder.AddColumn<int>(
                name: "NoOfSeason",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrdinalNumber",
                table: "Episodes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
