using Microsoft.EntityFrameworkCore;
using Quizlet_Server.Data;
using Quizlet_Server.Entities;
using Quizlet_Server.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizlet_Server.Services
{
    public class TaiKhoanService : ITaiKhoanService
    {
        private AppDbContext appDbContext { get; set; }
        public TaiKhoanService()
        {
            appDbContext = new AppDbContext();
        }
        public IQueryable<TaiKhoan> GetDanhSachTaiKhoan(int idlh)
        {
            var query = appDbContext.TaiKhoans.Include(x => x.LoaiTaiKhoan)
                                              .Include(x => x.LopHoc_HocSinhs)
                                              .Where(x => x.LopHoc_HocSinhs.Any(y => y.LopHocID == idlh))
                                              .AsQueryable();
            //var query = appDbContext.LopHoc_HocSinhs.Include(x => x.TaiKhoan)
            //                                   .Where(x => x.LopHocID == idlh)
            //                                  .AsQueryable();
            return query;
        }
        //public TaiKhoan GetTaiKhoanById(int taiKhoanId)
        //{
        //    var tk = appDbContext.TaiKhoans.Include(x => x.LoaiTaiKhoan)
        //                                   .AsQueryable()
        //                                   .FirstOrDefault(x => x.TaiKhoanID == taiKhoanId);
        //    return tk;
        //}
        public TaiKhoan GetTaiKhoanByEmailPass(string email, string password)
        {
            var tk = appDbContext.TaiKhoans.Include(x => x.LoaiTaiKhoan)
                                           .AsQueryable()
                                           .FirstOrDefault(x => x.Email == email && x.MatKhau == password);
            return tk;
        }
        public TaiKhoan GetTaiKhoanByEmail(string email)
        {
            var tk = appDbContext.TaiKhoans.Include(x => x.LoaiTaiKhoan)
                                           .AsQueryable()
                                           .FirstOrDefault(x => x.Email == email);
            return tk;
        }
        public TaiKhoan CreateTaiKhoan(TaiKhoan taiKhoan)
        {
            appDbContext.TaiKhoans.Add(taiKhoan);
            appDbContext.SaveChanges();
            return taiKhoan;
        }
        //public TaiKhoan UpdateTaiKhoan(int taiKhoanId, TaiKhoan taiKhoan)
        //{
        //    if (appDbContext.TaiKhoans.Any(sp => sp.TaiKhoanID == taiKhoanId))
        //    {
        //        var currentTaiKhoan = GetTaiKhoanById(taiKhoanId);
        //        currentTaiKhoan.Email = taiKhoan.Email;
        //        currentTaiKhoan.MatKhau = taiKhoan.MatKhau;
        //        currentTaiKhoan.TenNguoiDung = taiKhoan.TenNguoiDung;
        //        currentTaiKhoan.NgaySinh = taiKhoan.NgaySinh;
        //        appDbContext.TaiKhoans.Update(currentTaiKhoan);
        //        appDbContext.SaveChanges();
        //        return currentTaiKhoan;
        //    }
        //    else
        //        throw new Exception($"tai khoan {taiKhoanId} is not exist.");
        //}
        //public void DeleteTaiKhoan(int taiKhoanId)
        //{
        //    if (appDbContext.TaiKhoans.Any(tk => tk.TaiKhoanID == taiKhoanId))
        //    {
        //        var taiKhoanCanXoa = GetTaiKhoanById(taiKhoanId);
        //        appDbContext.TaiKhoans.Remove(taiKhoanCanXoa);
        //        appDbContext.SaveChanges();
        //    }
        //    else
        //    {
        //        throw new Exception($"Lop Hoc {taiKhoanId} is not exist.");
        //    }

        //}
    }
}