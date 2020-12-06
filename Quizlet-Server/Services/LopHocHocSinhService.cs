using Quizlet_Server.Data;
using Microsoft.EntityFrameworkCore;
using Quizlet_Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizlet_Server.Services
{
    public class LopHocHocSinhService
    {
        private AppDbContext appDbContext { get; set; }
        public LopHocHocSinhService()
        {
            appDbContext = new AppDbContext();
        }
        public LopHoc_HocSinh CreateLopHocHocSinh(LopHoc_HocSinh lhhs)
        {
            appDbContext.LopHoc_HocSinhs.Add(lhhs);
            appDbContext.SaveChanges();
            return lhhs;
        }
        public IQueryable<LopHoc_HocSinh> GetDanhSachLopHocByIDHocVien(int idhv)
        {
            var query = appDbContext.LopHoc_HocSinhs.Include(x => x.TaiKhoan)
                                            .Include(x => x.LopHoc.HocPhans)
                                            .Include(x => x.LopHoc.TaiKhoan)
                                            .Where(x => x.TaiKhoanID == idhv)
                                            .AsQueryable();
            return query;
        }
        public IQueryable<The>  GetDanhSachTheByHocPhanID(int idhp)
        {
            var query = appDbContext.Thes.Include(x => x.HocPhan).Where(x => x.HocPhanID == idhp).AsQueryable();
            return query;
        }
        public void DeleteHocVien(int hvId, int lhId)
        {
            if (appDbContext.LopHoc_HocSinhs.Any(lhhs => lhhs.TaiKhoanID == hvId && lhhs.LopHocID == lhId))
            {
                var hocVienCanXoa = appDbContext.LopHoc_HocSinhs
                                        .FirstOrDefault(x => x.TaiKhoanID == hvId && x.LopHocID == lhId);
                appDbContext.LopHoc_HocSinhs.Remove(hocVienCanXoa);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Lop Hoc {hvId} is not exist.");
            }
        }
    }
}