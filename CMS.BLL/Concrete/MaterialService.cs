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
    public class MaterialService : IMaterialService
    {
        IMaterialDAL _materialDAL;
        public MaterialService(IMaterialDAL materialDAL)
        {
            _materialDAL = materialDAL;
        }
        public void Delete(Material entity)
        {
            _materialDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Material Get(int entityID)
        {
            return _materialDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Material> GetAll()
        {
            return _materialDAL.GetAll();
        }

        public void Insert(Material entity)
        {
            _materialDAL.Add(entity);
        }

        public void Update(Material entity)
        {
            _materialDAL.Update(entity);
        }
    }
}
