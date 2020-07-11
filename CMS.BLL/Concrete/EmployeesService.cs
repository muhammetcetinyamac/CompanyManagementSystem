using CMS.BLL.Abstract;
using CMS.DAL.Abstract;
using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL.Concrete
{
    public class EmployeesService : IEmployeesService
    {
        IEmployeesDAL _employeesDAL;
        public EmployeesService(IEmployeesDAL employeesDAL)
        {
            _employeesDAL = employeesDAL;
        }
        public void Delete(Employees entity)
        {
            _employeesDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Employees Get(int entityID)
        {
            return _employeesDAL.Get(a => a.Id == entityID);
        }

       

        public ICollection<Employees> GetAll()
        {
            return _employeesDAL.GetAll();
        }

        public Employees GetUserByLogin(string tckn, string password)
        {
            return _employeesDAL.Get(a => a.TCKN == tckn && a.Password == password);
        }

        public Employees GetUserEmail(string eMail)
        {
            return _employeesDAL.Get(a => a.EMail == eMail);
        }
        public Employees GetUserTCKN(string tckn)
        {
            return _employeesDAL.Get(a => a.TCKN == tckn);
        }

        public void Insert(Employees entity)
        {
            _employeesDAL.Add(entity);
        }

        public void Update(Employees entity)
        {
            _employeesDAL.Update(entity);
        }
    }
}
