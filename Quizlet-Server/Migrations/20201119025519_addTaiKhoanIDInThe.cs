using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizlet_Server.Migrations
{
    public partial class addTaiKhoanIDInThe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaiKhoanID",
                table: "Thes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaiKhoanID",
                table: "Thes");
        }
    }
}
