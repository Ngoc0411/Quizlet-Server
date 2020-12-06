using Quizlet_Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet_Server.Interfaces.Services
{
    public interface ILopHocHocSinhService
    {
        LopHoc_HocSinh CreateLopHocHocSinh(LopHoc_HocSinh lhhs);
        IQueryable<LopHoc_HocSinh> GetDanhSachLopHocByIDHocVien(int idhv);
        IQueryable<The> GetDanhSachTheByHocPhanID(int idhv);
        void DeleteHocVien(int hvId, int lhId);
    }
}
