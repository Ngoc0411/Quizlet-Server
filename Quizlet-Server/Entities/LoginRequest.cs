using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quizlet_Server.Entities
{
    public class LoginRequest
    {
        public string TenNguoiDung { get; set; }
        public string MatKhau { get; set; }
        public bool RememberMe { get; set; }
    }
}