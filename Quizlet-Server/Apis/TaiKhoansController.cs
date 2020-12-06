using Quizlet_Server.Entities;
using Quizlet_Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Quizlet_Server.Apis
{
    [RoutePrefix("api/taikhoans")]
    public class TaiKhoansController : ApiController
    {
        private TaiKhoanService _taiKhoanService { get; set; }
        public TaiKhoansController()
        {
            _taiKhoanService = new TaiKhoanService();
        }
        [Route("{idlh}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDanhSachTaiKhoan(int idlh)
        {
            var query = _taiKhoanService.GetDanhSachTaiKhoan(idlh);
            var data = query.Select(tk => new
            {
                tk.TaiKhoanID,
                tk.TenNguoiDung,
                tk.Email,
                tk.NgaySinh,
                tk.LoaiTaiKhoan.LoaiTaiKhoanID,
                tk.LoaiTaiKhoan.TenLoaiTaiKhoan,
                tk.Anh,
            }).ToList();
            return Ok(data);
        }
        [Route("{email}/{password}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTaiKhoanByEmailPass(string email, string password)
        {
            var tk = _taiKhoanService.GetTaiKhoanByEmailPass(email, password);
            
            if (tk != null)
            {
                var data = new
                {
                    tk.TaiKhoanID,
                    tk.TenNguoiDung,
                    tk.Email,
                    tk.MatKhau,
                    tk.NgaySinh,
                    tk.LoaiTaiKhoan.LoaiTaiKhoanID,
                    tk.LoaiTaiKhoan.TenLoaiTaiKhoan,
                    tk.Anh,
                };
                return Ok(data);
            }
            return Ok();
        }
        
        //[Route("{id}")]
        //[HttpGet]
        //public async Task<IHttpActionResult> GetTaiKhoanById(int id)
        //{
        //    var tk = _taiKhoanService.GetTaiKhoanById(id);
        //    var data = new
        //    {
        //        tk.TaiKhoanID,
        //        tk.TenNguoiDung,
        //        tk.Email,
        //        tk.MatKhau,
        //        tk.NgaySinh,
        //        tk.LoaiTaiKhoan.LoaiTaiKhoanID,
        //        tk.LoaiTaiKhoan.TenLoaiTaiKhoan
        //    };
        //    return Ok(data);
        //}
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateTaiKhoan(TaiKhoan taiKhoan)
        {
            _taiKhoanService.CreateTaiKhoan(taiKhoan);
            return Ok(taiKhoan);
        }

        //[Route("{id}")]
        //[HttpPut]
        //public async Task<IHttpActionResult> UpdateTaiKhoan(int id, TaiKhoan taiKhoan)
        //{
        //    _taiKhoanService.UpdateTaiKhoan(id, taiKhoan);
        //    return Ok(taiKhoan);
        //}

        //[Route("{id}")]
        //[HttpDelete]
        //public async Task<IHttpActionResult> DeleteTaiKhoan(int id)
        //{
        //    _taiKhoanService.DeleteTaiKhoan(id);
        //    return Ok();
        //}

    }
}
