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
    public class HocPhanService : IHocPhanService
    {
        private AppDbContext appDbContext { get; set; }
        public HocPhanService()
        {
            appDbContext = new AppDbContext();
        }

        public IQueryable<HocPhan> GetDanhSachHocPhan(string keywords)
        {
            var query = appDbContext.HocPhans.Include(x => x.TaiKhoan)
                                            .Include(x => x.LopHoc)
                                            .AsQueryable();
            if (!string.IsNullOrEmpty(keywords))
            {
                keywords = keywords.ToLower();
                query = query.Where(hp => hp.TenHocPhan.ToLower().Contains(keywords)
                                    || hp.TaiKhoan.TenTaiKhoan.ToLower().Contains(keywords)
                                    || hp.MoTa.ToLower().Contains(keywords)
                                    );
            }
            return query;
        }

        public HocPhan GetHocPhanById(int hocPhanId)
        {
            var hp = appDbContext.HocPhans.Include(x => x.TaiKhoan)
                                            .Include(x => x.LopHoc)
                                            .AsQueryable()
                                            .FirstOrDefault(x => x.HocPhanID == hocPhanId);
            return hp;
        }

        public HocPhan CreateHocPhan(HocPhan hocPhan)
        {
            appDbContext.HocPhans.Add(hocPhan);
            appDbContext.SaveChanges();
            return hocPhan;
        }
        public HocPhan UpdateHocPhan(int hocPhanId, HocPhan hocPhan)
        {
            if (appDbContext.HocPhans.Any(hp => hp.HocPhanID == hocPhanId))
            {
                var currentHocPhan = GetHocPhanById(hocPhanId);
                currentHocPhan.TenHocPhan = hocPhan.TenHocPhan;
                currentHocPhan.MoTa = hocPhan.MoTa;
                appDbContext.HocPhans.Update(currentHocPhan);
                appDbContext.SaveChanges();
                return currentHocPhan;
            }
            else
                throw new Exception($" hoc phan {hocPhanId} is not exist.");
        }

        public void DeleteHocPhan(int hocPhanId)
        {
            if (appDbContext.HocPhans.Any(lh => lh.HocPhanID == hocPhanId))
            {
                var hocPhanCanXoa = GetHocPhanById(hocPhanId);
                appDbContext.HocPhans.Remove(hocPhanCanXoa);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new Exception($" hoc phan {hocPhanId} is not exist.");
            }

        }
        public IQueryable<The> GetDanhSachTheByHocPhanID(int hocPhanID)
        {
            var query = appDbContext.Thes.Include(x => x.HocPhan).AsQueryable();
            query = query.Where(t => t.HocPhanID == hocPhanID);
            return query;
        }
    }
}