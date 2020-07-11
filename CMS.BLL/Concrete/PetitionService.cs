using CMS.BLL.Abstract;
using CMS.DAL.Abstract;
using CMS.MODEL.Entities;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL.Concrete
{
    public class PetitionService : IPetitionService
    {
        IPetitionDAL _petitionDAL;
        public PetitionService(IPetitionDAL petitionDAL)
        {
            _petitionDAL = petitionDAL;
        }
        public void Delete(Petition entity)
        {
            _petitionDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Petition Get(int entityID)
        {
            return _petitionDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Petition> GetAll()
        {
            return _petitionDAL.GetAll();
        }

        public void Insert(Petition entity)
        {
            _petitionDAL.Add(entity);
        }

        public ICollection<Petition> pendingPetition(TransactionStatus confirmation)
        {
            return _petitionDAL.GetAll().Where(x=>x.Confirmation == confirmation).ToList();
        }

        public void Update(Petition entity)
        {
            _petitionDAL.Update(entity);
        }
    }
}
