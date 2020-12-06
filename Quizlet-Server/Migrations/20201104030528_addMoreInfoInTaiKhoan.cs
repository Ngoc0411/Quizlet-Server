using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizlet_Server.Migrations
{
    public partial class addMoreInfoInTaiKhoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "TaiKhoans");

            migrationBuilder.DropColumn(
                name: "TenTaiKhoan",
                table: "TaiKhoans");

            migrationBuilder.AddColumn<string>(
                name: "MatKhau",
                table: "TaiKhoans",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgaySinh",
                table: "TaiKhoans",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TenNguoiDung",
                table: "TaiKhoans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatKhau",
                table: "TaiKhoans");

            migrationBuilder.DropColumn(
                name: "NgaySinh",
                table: "TaiKhoans");

            migrationBuilder.DropColumn(
                name: "TenNguoiDung",
                table: "TaiKhoans");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "TaiKhoans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenTaiKhoan",
                table: "TaiKhoans",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
