using Microsoft.EntityFrameworkCore.Migrations;

namespace MurrrcatConsoleCodeFirst.Migrations
{
    public partial class AddedOwnerRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Owner",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Owner");
        }
    }
}
