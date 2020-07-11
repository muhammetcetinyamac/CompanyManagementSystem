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
    public class CustomersService : ICustomersService
    {
        ICustomersDAL _customersDAL;
        public CustomersService(ICustomersDAL customersDAL)
        {
            _customersDAL = customersDAL;
        }
        public void Delete(Customers entity)
        {
            _customersDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Customers Get(int entityID)
        {
            return _customersDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Customers> GetAll()
        {
            return _customersDAL.GetAll();
        }

        public void Insert(Customers entity)
        {
            _customersDAL.Add(entity);
        }

        public void Update(Customers entity)
        {
            _customersDAL.Update(entity);
        }
    }
}
