using Quizlet_Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet_Server.Interfaces.Services
{
    interface ILopHocService
    {
        IQueryable<LopHoc> GetDanhSachLopHoc(string keywords);
        LopHoc GetLopHocById(int lopHocId);
        LopHoc CreateLopHoc(LopHoc lopHoc);
        LopHoc UpdateLopHoc(int lopHocId, LopHoc lopHoc);
        void DeleteLopHoc(int lopHocId);
    }
}
