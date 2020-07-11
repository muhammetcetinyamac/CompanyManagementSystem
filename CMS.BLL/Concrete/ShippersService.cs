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
    public class ShippersService : IShippersService
    {
        IShippersDAL _shippersDAL;
        public ShippersService(IShippersDAL shippersDAL)
        {
            _shippersDAL = shippersDAL;
        }
        public void Delete(Shippers entity)
        {
            _shippersDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Shippers Get(int entityID)
        {
            return _shippersDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Shippers> GetAll()
        {
            return _shippersDAL.GetAll();
        }

        public void Insert(Shippers entity)
        {
            _shippersDAL.Add(entity);
        }

        public void Update(Shippers entity)
        {
            _shippersDAL.Update(entity);
        }
    }
}
