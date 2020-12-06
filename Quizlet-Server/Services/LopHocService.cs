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
    public class LopHocService : ILopHocService
    {
        private AppDbContext appDbContext { get; set; }
        public LopHocService()
        {
            appDbContext = new AppDbContext();
        }

        public IQueryable<LopHoc> GetDanhSachLopHoc(int TKId, string keywords)
        {
            var query = appDbContext.LopHocs.Include(x => x.TaiKhoan)
                                            .Include(x => x.LopHoc_HocSinhs)
                                            .Include(x => x.HocPhans)
                                            .Where(x => x.TaiKhoanID == TKId)
                                            .AsQueryable();
            //if (keywords == "all") return query;
            //if (!string.IsNullOrEmpty(keywords))
            //{
            //    keywords = keywords.ToLower();
            //    query = query.Where(lh => lh.TenLopHoc.ToLower().Contains(keywords)
            //                        || lh.TaiKhoan.TenNguoiDung.ToLower().Contains(keywords)
            //                        || lh.MoTa.ToLower().Contains(keywords)
            //                        );
            //}
            return query;
        }

        public LopHoc GetLopHocById(int lopHocId)
        {
            var lh = appDbContext.LopHocs.Include(x => x.TaiKhoan)
                                        .Include(x => x.LopHoc_HocSinhs)
                                        .Include(x => x.HocPhans)
                                        .AsQueryable()
                                        .FirstOrDefault(x => x.LopHocID == lopHocId);
            return lh;
        }

        public LopHoc CreateLopHoc(LopHoc lopHoc)
        {
            appDbContext.LopHocs.Add(lopHoc);
            appDbContext.SaveChanges();
            return lopHoc;
        }
        public LopHoc UpdateLopHoc(int lopHocId, LopHoc lopHoc)
        {
            if (appDbContext.LopHocs.Any(sp => sp.LopHocID == lopHocId))
            {
                var currentLopHoc = GetLopHocById(lopHocId);
                currentLopHoc.TenLopHoc = lopHoc.TenLopHoc;
                currentLopHoc.MoTa = lopHoc.MoTa;
                appDbContext.LopHocs.Update(currentLopHoc);
                appDbContext.SaveChanges();
                return currentLopHoc;
            }
            else
                throw new Exception($"lop hoc {lopHocId} is not exist.");
        }

        public void DeleteLopHoc(int lopHocId)
        {
            if (appDbContext.LopHocs.Any(lh => lh.LopHocID == lopHocId))
            {
                var lopHocCanXoa = GetLopHocById(lopHocId);
                appDbContext.LopHocs.Remove(lopHocCanXoa);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"Lop Hoc {lopHocId} is not exist.");
            }
        }
        public IQueryable<LopHoc_HocSinh> GetDanhSachHocVienByLopHocID(int lopHocID)
        {
            var query = appDbContext.LopHoc_HocSinhs.Include(x => x.LopHoc).AsQueryable();
            query = query.Where(hv => hv.LopHocID == lopHocID);
            return query;
        }
        public IQueryable<HocPhan> GetDanhSachHocPhanByLopHocID(int lopHocID)
        {
            var query = appDbContext.HocPhans.Include(x => x.LopHoc).AsQueryable();
            query = query.Where(hp => hp.LopHocID == lopHocID);
            return query;
        }
    }
}