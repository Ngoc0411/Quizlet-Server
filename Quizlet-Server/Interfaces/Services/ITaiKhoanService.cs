﻿using Quizlet_Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet_Server.Interfaces.Services
{
    public interface ITaiKhoanService
    {
        IQueryable<TaiKhoan> GetDanhSachTaiKhoan(int idlh);
        TaiKhoan GetTaiKhoanByEmailPass(string email, string password);
        TaiKhoan GetTaiKhoanByEmail(string email);
        //TaiKhoan GetTaiKhoanById(int taiKhoanId);
        TaiKhoan CreateTaiKhoan(TaiKhoan taiKhoan);
        //TaiKhoan UpdateTaiKhoan(int lopHocId, TaiKhoan taiKhoan);
        //void DeleteTaiKhoan(int taiKhoanId);
    }
}
