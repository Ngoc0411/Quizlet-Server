using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizlet_Server.Entities
{
    public class LopHoc_HocSinh
    {
        public int LopHoc_HocSinhID { get; set; }
        public int LopHocID { get; set; }
        public virtual LopHoc LopHoc { get; set; }
        public int TaiKhoanID { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}