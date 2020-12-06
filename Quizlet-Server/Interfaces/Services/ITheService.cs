using Quizlet_Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizlet_Server.Interfaces.Services
{
    public interface ITheService
    {
        IQueryable<The> GetDanhSachThe(int TKId);
        The GetTheById(int theId);
        The CreateThe(The the);
        The UpdateThe(int theId, The the);
        void DeleteThe(int theId);
    }
}
