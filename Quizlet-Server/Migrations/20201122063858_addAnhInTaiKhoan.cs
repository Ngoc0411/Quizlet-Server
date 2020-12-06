using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizlet_Server.Migrations
{
    public partial class addAnhInTaiKhoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anh",
                table: "TaiKhoans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anh",
                table: "TaiKhoans");
        }
    }
}
