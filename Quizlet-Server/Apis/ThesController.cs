using Microsoft.AspNetCore.Hosting;
using Quizlet_Server.Entities;
using Quizlet_Server.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Quizlet_Server.Apis
{
    [RoutePrefix("api/thes")]
    public class ThesController : ApiController
    {
        private TheService _theService { get; set; }
        public ThesController()
        {
            _theService = new TheService();
        }
        [Route("{TKId}/{par}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetDanhSachThe(int TKId, string par)
        { 
            var query = _theService.GetDanhSachThe(TKId);
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

        [Route("{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTheById(int id)
        {
            var t = _theService.GetTheById(id);
            var data = new
            {
                t.TheID,
                t.HocPhanID,
                t.ThuatNgu,
                t.GiaiNghia,
                t.Anh,
                t.NgayTao,
                t.PhatAm,
                t.CachSuDung,
            };
            return Ok(data);
        }

        [Route("")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateThe(The the)
        {
            _theService.CreateThe(the);
            return Ok(the);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateThe(int id, The the)
        {
            _theService.UpdateThe(id, the);
            return Ok(the);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteThe(int id)
        {
            _theService.DeleteThe(id);
            return Ok();
        }
    }
}
