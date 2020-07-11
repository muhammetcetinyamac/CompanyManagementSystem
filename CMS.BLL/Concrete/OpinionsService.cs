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
    public class OpinionsService : IOpinionsService
    {
        IOpinionsDAL _opinionsDAL;
        public OpinionsService(IOpinionsDAL opinionsDAL)
        {
            _opinionsDAL = opinionsDAL;
        }

        public void Delete(Opinions entity)
        {
            _opinionsDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Opinions Get(int entityID)
        {
            return _opinionsDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Opinions> GetAll()
        {
            return _opinionsDAL.GetAll();
        }       

        public void Insert(Opinions entity)
        {
            _opinionsDAL.Add(entity);
        }

        public void Update(Opinions entity)
        {
            _opinionsDAL.Update(entity);
        }
    }
}
