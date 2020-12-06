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
    [RoutePrefix("api/hocphans")]
    public class HocPhansController : ApiController
    {
        //test
        private HocPhanService _hocPhanService { get; set; }
        public HocPhansController()
        {
            _hocPhanService = new HocPhanService();
        }
        [Route("{lhid}/{keywords}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDanhSachHocPhan(int lhid,string keywords)
        {
            var query = _hocPhanService.GetDanhSachHocPhan(lhid);
            var data = query.Select(hp => new
            {
                hp.HocPhanID,
                hp.TaiKhoanID,
                hp.TenHocPhan,
                hp.MoTa,
                hp.LopHocID,
                Soluongthe = hp.Thes.Count(),
            }).ToList();
            return Ok(data);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetHocPhanById(int id)
        {
            var hp = _hocPhanService.GetHocPhanById(id);
            var data = new
            {
                hp.HocPhanID,
                hp.TaiKhoanID,
                hp.TenHocPhan,
                hp.MoTa,
                hp.LopHocID,
                Soluongthe = hp.Thes.Count(),
            };
            return Ok(data);
        }
        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateHocPhan(HocPhan hocPhan)
        {
            _hocPhanService.CreateHocPhan(hocPhan);
            return Ok(hocPhan);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateHocPhan(int id, HocPhan hocPhan)
        {
            _hocPhanService.UpdateHocPhan(id, hocPhan);
            return Ok(hocPhan);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteHocPhan(int id)
        {
            _hocPhanService.DeleteHocPhan(id);
            return Ok();
        }

        [Route("danhsachthecuahocphan{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDanhSachHocVienByLopHocID(int id)
        {
            var query = _hocPhanService.GetDanhSachTheByHocPhanID(id);
            var data = query.Select(t => new
            {
                t.TheID,
                t.ThuatNgu,
                t.GiaiNghia,
            }).ToList();
            return Ok(data);
        }
    }
}
