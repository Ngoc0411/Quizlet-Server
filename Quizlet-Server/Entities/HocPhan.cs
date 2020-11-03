using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizlet_Server.Entities
{
    public class HocPhan
    {
        public int HocPhanID { get; set; }
        public int TaiKhoanID { get; set; }
        public string TenHocPhan { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public string MoTa { get; set; }
        public int LopHocID { get; set; }
        public virtual LopHoc LopHoc { get; set; }
        public virtual IEnumerable<The> Thes { get; set; }
    }
}