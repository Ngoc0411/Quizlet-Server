using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizlet_Server.Entities
{
    public class BaiKiemTra
    {
        public int BaiKiemTraID { get; set; }
        public string TenBaiKiemTra { get; set; }
        public int HocPhanID { get; set; }
        public virtual HocPhan HocPhan { get; set; }
    }
}