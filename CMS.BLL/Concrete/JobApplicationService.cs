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
    public class JobApplicationService : IJobApplicationService
    {
        IJobApplicationDAL _jobApplicationDAL;
        public JobApplicationService(IJobApplicationDAL jobApplicationDAL)
        {
            _jobApplicationDAL = jobApplicationDAL;
        }
        public void Delete(JobApplication entity)
        {
            _jobApplicationDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public JobApplication Get(int entityID)
        {
            return _jobApplicationDAL.Get(a => a.Id == entityID);
        }

        public ICollection<JobApplication> GetAll()
        {
            return _jobApplicationDAL.GetAll();
        }

        public void Insert(JobApplication entity)
        {
            _jobApplicationDAL.Add(entity);
        }

        public void Update(JobApplication entity)
        {
            _jobApplicationDAL.Update(entity);
        }
    }
}
