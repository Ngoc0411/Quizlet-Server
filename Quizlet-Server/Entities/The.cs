using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizlet_Server.Entities
{
    public class The
    {
        public int TheID { get; set; }
        public string Anh { get; set; }
        public string ThuatNgu { get; set; }
        public string GiaiNghia { get; set; }
        public string PhatAm { get; set; }
        public string CachSuDung { get; set; }
        public int HocPhanID { get; set; }
        public int TaiKhoanID { get; set; }
        public DateTime NgayTao { get; set; }
        public virtual HocPhan HocPhan { get; set; }
    }
}