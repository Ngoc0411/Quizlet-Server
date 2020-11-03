using Microsoft.EntityFrameworkCore;
using Quizlet_Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizlet_Server.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }
        public DbSet<LopHoc> LopHocs { get; set; }
        public DbSet<HocPhan> HocPhans { get; set; }
        public DbSet<The> Thes { get; set; }
        public DbSet<BaiKiemTra> BaiKiemTras { get; set; }
        public DbSet<LopHoc_HocSinh> LopHoc_HocSinhs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost; initial catalog=QuizletDb; user id=sa; password=04112000");
        }
    }
}