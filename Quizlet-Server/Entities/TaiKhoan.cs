using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizlet_Server.Entities
{
    public class TaiKhoan
    {
        public int TaiKhoanID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TenTaiKhoan { get; set; }
        public int LoaiTaiKhoanID { get; set; }
        public virtual LoaiTaiKhoan LoaiTaiKhoan { get; set; }
        public virtual IEnumerable<LopHoc> LopHocs { get; set; }
        public virtual IEnumerable<HocPhan> HocPhans { get; set; }
        public virtual IEnumerable<LopHoc_HocSinh> LopHoc_HocSinhs { get; set; }
    }
}