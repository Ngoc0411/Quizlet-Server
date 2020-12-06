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
    [RoutePrefix("api/lophochocsinhs")]
    public class LopHoc_HocSinhsController : ApiController
    {
        private LopHocHocSinhService _lopHocHocSinhService { get; set; }
        private TaiKhoanService _taiKhoanService { get; set; }
        public LopHoc_HocSinhsController()
        {
            _lopHocHocSinhService = new LopHocHocSinhService();
            _taiKhoanService = new TaiKhoanService();
        }

        [Route("{email}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTaiKhoanByEmail(string email)
        {
            var tk = _taiKhoanService.GetTaiKhoanByEmail(email);

            if (tk != null)
            {
                var data = new
                {
                    tk.TaiKhoanID,
                    tk.TenNguoiDung,
                    tk.Email
                };
                return Ok(data);
            }
            return Ok();
        }
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateLopHocHocSinh(LopHoc_HocSinh lhhs)
        {
            _lopHocHocSinhService.CreateLopHocHocSinh(lhhs);
            return Ok(lhhs);
        }

        [Route("{idhv}/{abc}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDanhSachLopHocByIDHocVien(int idhv)
        {
            var query = _lopHocHocSinhService.GetDanhSachLopHocByIDHocVien(idhv);

            var data = query.Select(dslh => new
            {
                dslh.LopHoc,
                SoLuongHocPhan = dslh.LopHoc.HocPhans.Count(),
                SoLuongHocVien = dslh.LopHoc.LopHoc_HocSinhs.Count(),
            }).ToList();
            return Ok(data);
        }
        [Route("{idhp}/{abc}/{def}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDanhSachTheByHocPhanID(int idhp)
        {
            var query = _lopHocHocSinhService.GetDanhSachTheByHocPhanID(idhp);

            var data = query.Select(t => new
            {
                t.TheID,
                t.HocPhanID,
                t.ThuatNgu,
                t.GiaiNghia,
                t.Anh,
                t.NgayTao,
                t.PhatAm,
                t.CachSuDung,
            }).ToList();
            return Ok(data);
        }
        [Route("{idhv}/{idlh}/{def}/{ghi}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteHocVien(int idhv, int idlh)
        {
            _lopHocHocSinhService.DeleteHocVien(idhv, idlh);
            return Ok();
        }
    }
}
