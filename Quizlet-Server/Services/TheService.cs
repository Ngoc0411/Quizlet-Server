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
    public class TheService : ITheService
    {
        private AppDbContext appDbContext { get; set; }
        public TheService()
        {
            appDbContext = new AppDbContext();
        }
        public IQueryable<The> GetDanhSachThe(int TKId)
        {
            var query = appDbContext.Thes.Include(x => x.HocPhan).Where(x => x.TaiKhoanID == TKId).AsQueryable();
            //var query = appDbContext.Thes.Where(x => x.TaiKhoanID == TKId).AsQueryable();
            //if (!string.IsNullOrEmpty(keywords))
            //{
            //    keywords = keywords.ToLower();
            //    query = query.Where(t => t.ThuatNgu.ToLower().Contains(keywords)
            //                        || t.GiaiNghia.ToLower().Contains(keywords)
            //                        );
            //}
            return query;
        }

        public The GetTheById(int theId)
        {
            var t = appDbContext.Thes.AsQueryable()
                                     .FirstOrDefault(x => x.TheID == theId);
            return t;
        }
        public The CreateThe(The the)
        {
            appDbContext.Thes.Add(the);
            appDbContext.SaveChanges();
            return the;
        }
        public The UpdateThe(int theId, The the)
        {
            if (appDbContext.Thes.Any(sp => sp.TheID == theId))
            {
                var currentThe = GetTheById(theId);
                currentThe.ThuatNgu = the.ThuatNgu;
                currentThe.Anh = the.Anh;
                currentThe.GiaiNghia = the.GiaiNghia;
                currentThe.PhatAm = the.PhatAm;
                currentThe.CachSuDung = the.CachSuDung;
                appDbContext.Thes.Update(currentThe);
                appDbContext.SaveChanges();
                return currentThe;
            }
            else
                throw new Exception($"the {theId} is not exist.");
        }
        public void DeleteThe(int theId)
        {
            if (appDbContext.Thes.Any(t => t.TheID == theId))
            {
                var theCanXoa = GetTheById(theId);
                appDbContext.Thes.Remove(theCanXoa);
                appDbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"the {theId} is not exist.");
            }
        }
        public IQueryable<The> GetDanhSachTheByHocPhanID(int hocPhanID)
        {
            var query = appDbContext.Thes.Include(x => x.HocPhan).AsQueryable();
            query = query.Where(t => t.HocPhan.HocPhanID == hocPhanID);
            return query;
        }

    }
}