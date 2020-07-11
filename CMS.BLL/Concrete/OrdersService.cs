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
    public class OrdersService : IOrdersService
    {
        IOrdersDAL _ordersDAL;
        public OrdersService(IOrdersDAL ordersDAL)
        {
            _ordersDAL = ordersDAL;
        }
        public void Delete(Orders entity)
        {
            _ordersDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Orders Get(int entityID)
        {
            return _ordersDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Orders> GetAll()
        {
            return _ordersDAL.GetAll();
        }

        public void Insert(Orders entity)
        {
            _ordersDAL.Add(entity);
        }

        public void Update(Orders entity)
        {
            _ordersDAL.Update(entity);
        }
    }
}
