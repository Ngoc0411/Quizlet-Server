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
    [RoutePrefix("api/uploads")]
    public class UploadsController : ApiController
    {
        [Route("")]
        [HttpPost]
        public async Task<string> Upload()
        {
            var file = HttpContext.Current.Request.Files[0];

            if (file != null && file.ContentLength > 0)
            {
                var rd = RamdomString(20);
                var fileName = Path.GetFileName(file.FileName).Replace("\"", "").Split('.');
                var fn = rd + '.' + fileName[fileName.Length - 1];

                while (System.IO.File.Exists(fn))
                {
                    rd = RamdomString(20);
                    fn = rd + '.' + fileName[fileName.Length - 1];
                }

                var path = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/HinhAnh"),
                    fn
                );

                file.SaveAs(path);
                return "/HinhAnh/" + fn;
            }
            return "";
        }
        public static string RamdomString(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;

            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(36);
                if (temp != -1 && temp == t)
                {
                    return RamdomString(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }
    }
}
