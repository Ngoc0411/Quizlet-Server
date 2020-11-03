using Microsoft.EntityFrameworkCore.Migrations;

namespace Quizlet_Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiTaiKhoans",
                columns: table => new
                {
                    LoaiTaiKhoanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiTaiKhoan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiTaiKhoans", x => x.LoaiTaiKhoanID);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    TaiKhoanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TenTaiKhoan = table.Column<string>(nullable: true),
                    LoaiTaiKhoanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.TaiKhoanID);
                    table.ForeignKey(
                        name: "FK_TaiKhoans_LoaiTaiKhoans_LoaiTaiKhoanID",
                        column: x => x.LoaiTaiKhoanID,
                        principalTable: "LoaiTaiKhoans",
                        principalColumn: "LoaiTaiKhoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHocs",
                columns: table => new
                {
                    LopHocID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoanID = table.Column<int>(nullable: false),
                    TenLopHoc = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocs", x => x.LopHocID);
                    table.ForeignKey(
                        name: "FK_LopHocs_TaiKhoans_TaiKhoanID",
                        column: x => x.TaiKhoanID,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaiKhoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HocPhans",
                columns: table => new
                {
                    HocPhanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoanID = table.Column<int>(nullable: false),
                    TenHocPhan = table.Column<string>(nullable: true),
                    MoTa = table.Column<string>(nullable: true),
                    LopHocID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocPhans", x => x.HocPhanID);
                    table.ForeignKey(
                        name: "FK_HocPhans_LopHocs_LopHocID",
                        column: x => x.LopHocID,
                        principalTable: "LopHocs",
                        principalColumn: "LopHocID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HocPhans_TaiKhoans_TaiKhoanID",
                        column: x => x.TaiKhoanID,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaiKhoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc_HocSinhs",
                columns: table => new
                {
                    LopHoc_HocSinhID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LopHocID = table.Column<int>(nullable: false),
                    TaiKhoanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc_HocSinhs", x => x.LopHoc_HocSinhID);
                    table.ForeignKey(
                        name: "FK_LopHoc_HocSinhs_LopHocs_LopHocID",
                        column: x => x.LopHocID,
                        principalTable: "LopHocs",
                        principalColumn: "LopHocID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LopHoc_HocSinhs_TaiKhoans_TaiKhoanID",
                        column: x => x.TaiKhoanID,
                        principalTable: "TaiKhoans",
                        principalColumn: "TaiKhoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaiKiemTras",
                columns: table => new
                {
                    BaiKiemTraID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBaiKiemTra = table.Column<string>(nullable: true),
                    HocPhanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiKiemTras", x => x.BaiKiemTraID);
                    table.ForeignKey(
                        name: "FK_BaiKiemTras_HocPhans_HocPhanID",
                        column: x => x.HocPhanID,
                        principalTable: "HocPhans",
                        principalColumn: "HocPhanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thes",
                columns: table => new
                {
                    TheID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anh = table.Column<string>(nullable: true),
                    ThuatNgu = table.Column<string>(nullable: true),
                    GiaiNghia = table.Column<string>(nullable: true),
                    HocPhanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thes", x => x.TheID);
                    table.ForeignKey(
                        name: "FK_Thes_HocPhans_HocPhanID",
                        column: x => x.HocPhanID,
                        principalTable: "HocPhans",
                        principalColumn: "HocPhanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiKiemTras_HocPhanID",
                table: "BaiKiemTras",
                column: "HocPhanID");

            migrationBuilder.CreateIndex(
                name: "IX_HocPhans_LopHocID",
                table: "HocPhans",
                column: "LopHocID");

            migrationBuilder.CreateIndex(
                name: "IX_HocPhans_TaiKhoanID",
                table: "HocPhans",
                column: "TaiKhoanID");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_HocSinhs_LopHocID",
                table: "LopHoc_HocSinhs",
                column: "LopHocID");

            migrationBuilder.CreateIndex(
                name: "IX_LopHoc_HocSinhs_TaiKhoanID",
                table: "LopHoc_HocSinhs",
                column: "TaiKhoanID");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocs_TaiKhoanID",
                table: "LopHocs",
                column: "TaiKhoanID");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoans_LoaiTaiKhoanID",
                table: "TaiKhoans",
                column: "LoaiTaiKhoanID");

            migrationBuilder.CreateIndex(
                name: "IX_Thes_HocPhanID",
                table: "Thes",
                column: "HocPhanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiKiemTras");

            migrationBuilder.DropTable(
                name: "LopHoc_HocSinhs");

            migrationBuilder.DropTable(
                name: "Thes");

            migrationBuilder.DropTable(
                name: "HocPhans");

            migrationBuilder.DropTable(
                name: "LopHocs");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "LoaiTaiKhoans");
        }
    }
}
