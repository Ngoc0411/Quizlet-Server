using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizlet_Server.Migrations
{
    public partial class addPhatAmCachSDInThe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CachSuDung",
                table: "Thes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhatAm",
                table: "Thes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CachSuDung",
                table: "Thes");

            migrationBuilder.DropColumn(
                name: "PhatAm",
                table: "Thes");
        }
    }
}
