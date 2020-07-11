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
    public class AnnouncementService : IAnnouncementService
    {
        IAnnouncementDAL _announcementDAL;
        public AnnouncementService(IAnnouncementDAL announcementDAL)
        {
            _announcementDAL = announcementDAL;
        }
        public void Delete(Announcement entity)
        {
            _announcementDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Announcement Get(int entityID)
        {
            return _announcementDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Announcement> GetAll()
        {
            return _announcementDAL.GetAll();
        }

        public List<Announcement> GetLastTenAnnouncement()
        {
            return _announcementDAL.GetAll().OrderByDescending(a => a.CreatedDate).Take(10).ToList();
        }

        public void Insert(Announcement entity)
        {
            _announcementDAL.Add(entity);
        }

        public void Update(Announcement entity)
        {
            _announcementDAL.Update(entity);
        }
       
    }
}
