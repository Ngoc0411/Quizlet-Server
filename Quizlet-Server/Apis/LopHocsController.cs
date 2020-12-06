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
    [RoutePrefix("api/lophocs")]
    public class LopHocsController : ApiController
    {
        private LopHocService _lopHocService { get; set; }
        public LopHocsController()
        {
            _lopHocService = new LopHocService();
        }
        [Route("{TKId}/{keywords}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDanhSachLopHoc(int TKId, string keywords)
        {
            var query = _lopHocService.GetDanhSachLopHoc(TKId, keywords);
            var data = query.Select(lh => new
            {
                lh.LopHocID,
                lh.TenLopHoc,
                lh.MoTa,
                lh.NgayTao,
                SoLuongHocVien = lh.LopHoc_HocSinhs.Count(),
                SoLuongHocPhan = lh.HocPhans.Count(),
            }).ToList();
            return Ok(data);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetLopHocById(int id)
        {
            var lh = _lopHocService.GetLopHocById(id);
            var data = new
            {
                lh.LopHocID,
                lh.TenLopHoc,
                lh.MoTa,
                lh.NgayTao,
                SoLuongHocVien = lh.LopHoc_HocSinhs.Count(),
                SoLuongHocPhan = lh.HocPhans.Count(),
            };
            return Ok(data);
        }
        //[Route("danhsachhocsinhlop{id}")]
        //[HttpGet]
        //public async Task<IHttpActionResult> GetDanhSachHocVienByLopHocID(int id)
        //{
        //    var query = _lopHocService.GetDanhSachHocVienByLopHocID(id);
        //    var data = query.Select(lh => new
        //    {
        //        lh.TaiKhoanID,
        //        lh.TaiKhoan.TenNguoiDung
        //    }).ToList();
        //    return Ok(data);
        //}

        //[Route("danhsachhocphanlop{id}")]
        //[HttpGet]
        //public async Task<IHttpActionResult> GetDanhSachHocPhanByLopHocID(int id)
        //{
        //    var query = _lopHocService.GetDanhSachHocPhanByLopHocID(id);
        //    var data = query.Select(hp => new
        //    {
        //        hp.HocPhanID,
        //        hp.TenHocPhan,
        //        hp.MoTa
        //    }).ToList();
        //    return Ok(data);
        //}

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateLopHoc(LopHoc lopHoc)
        {
            lopHoc.NgayTao = DateTime.Now;
            _lopHocService.CreateLopHoc(lopHoc);
            return Ok(lopHoc);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateLopHoc(int id, LopHoc lopHoc)
        {
            _lopHocService.UpdateLopHoc(id, lopHoc);
            return Ok(lopHoc);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteLopHoc(int id)
        {
            _lopHocService.DeleteLopHoc(id);
            return Ok();
        }

    }
}
