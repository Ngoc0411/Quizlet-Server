using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizlet_Server.Entities
{
    public class LoaiTaiKhoan
    {
        public int LoaiTaiKhoanID { get; set; }
        public string TenLoaiTaiKhoan { get; set; }
        public virtual IEnumerable<TaiKhoan> TaiKhoans { get; set; }
    }
}