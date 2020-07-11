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
    public class ReportService : IReportService
    {
        IReportDAL _reportDAL;
        public ReportService(IReportDAL reportDAL)
        {
            _reportDAL = reportDAL;
            
        }
        public void Delete(Report entity)
        {
            _reportDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Report Get(int entityID)
        {
            return _reportDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Report> GetAll()
        {
            return _reportDAL.GetAll();
        }

        public void Insert(Report entity)
        {
            _reportDAL.Add(entity);
        }

        public void Update(Report entity)
        {
            _reportDAL.Update(entity);
        }
    }
}
