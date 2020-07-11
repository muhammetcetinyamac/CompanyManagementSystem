using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL.Abstract
{   
    public interface IEmployeesService : IBaseService<Employees>
    {
        Employees GetUserByLogin(string eMail, string password);
        Employees GetUserEmail(string eMail);
        Employees GetUserTCKN(string Tckn);

    }
}
