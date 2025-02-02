﻿using Quizlet_Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet_Server.Interfaces.Services
{
    public interface IHocPhanService
    {
        IQueryable<HocPhan> GetDanhSachHocPhan(int lhid);
        HocPhan GetHocPhanById(int hocPhanId);
        HocPhan CreateHocPhan(HocPhan hocPhan);
        HocPhan UpdateHocPhan(int hocPhanId, HocPhan hocPhan);
        void DeleteHocPhan(int hocPhanId);
    }
}
