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
        public int HocPhanID { get; set; }
        public virtual HocPhan HocPhan { get; set; }
    }
}