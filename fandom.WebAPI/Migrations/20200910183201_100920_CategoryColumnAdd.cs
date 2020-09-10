using Microsoft.EntityFrameworkCore.Migrations;

namespace fandom.WebAPI.Migrations
{
    public partial class _100920_CategoryColumnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryColor",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryColor",
                table: "Categories");
        }
    }
}
