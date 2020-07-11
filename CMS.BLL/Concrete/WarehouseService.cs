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
    public class WarehouseService : IWarehouseService
    {
        IWarehouseDAL _warehouseDAL;
        public WarehouseService(IWarehouseDAL warehouseDAL)
        {
            _warehouseDAL = warehouseDAL;
        }
        public void Delete(Warehouse entity)
        {
            _warehouseDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }       

        public Warehouse Get(int entityID)
        {
            return _warehouseDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Warehouse> GetAll()
        {
            return _warehouseDAL.GetAll();
        }

        public void Insert(Warehouse entity)
        {
            _warehouseDAL.Add(entity);
        }

        public void Update(Warehouse entity)
        {
            _warehouseDAL.Update(entity);
        }
    }
}
