using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizlet_Server.Entities
{
    public class LopHoc
    {
        public int LopHocID { get; set; }
        public int TaiKhoanID { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public string TenLopHoc { get; set; }
        public string MoTa { get; set; }
        public virtual IEnumerable<LopHoc_HocSinh> LopHoc_HocSinhs { get; set; }
        public virtual IEnumerable<HocPhan> HocPhans { get; set; }
    }
}