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
    public class SuppliersService : ISuppliersService
    {
        ISuppliersDAL _suppliersDAL;
        public SuppliersService(ISuppliersDAL suppliersDAL)
        {
            _suppliersDAL = suppliersDAL;
        }
        public void Delete(Suppliers entity)
        {
            _suppliersDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Suppliers Get(int entityID)
        {
            return _suppliersDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Suppliers> GetAll()
        {
            return _suppliersDAL.GetAll();
        }

        public void Insert(Suppliers entity)
        {
            _suppliersDAL.Add(entity);
        }

        public void Update(Suppliers entity)
        {
            _suppliersDAL.Update(entity);
        }
    }
}
