using CMS.BLL.Abstract;
using CMS.MODEL.Entities;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.UI.MVC.Areas.BusinessStructure.Controllers.Transactions
{
    public class AnnouncementController : Controller
    {
        // GET: BusinessStructure/Announcement
        IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        public ActionResult Index()
        {          
            return View(_announcementService.GetAll().ToList());
        }
        [HttpPost]
        public ActionResult Add(Announcement announcement)
        {
            announcement.IsActive = true;
            announcement.EmployeesID = Convert.ToInt32(Session["UserId"]);
            announcement.ModifiedDate = DateTime.Now;
            _announcementService.Insert(announcement);
            return RedirectToAction("Index", "Announcement");
        }
        public ActionResult Update(int id)
        {           
            return View(_announcementService.Get(id));
        }
        [HttpPost]
        public ActionResult Update(Announcement announcement)
        {
            var currentAnnouncement = _announcementService.Get(announcement.Id);
            currentAnnouncement.Content = announcement.Content;
            currentAnnouncement.ModifiedDate = DateTime.Now;
            _announcementService.Update(currentAnnouncement);
            return RedirectToAction("Index", "Announcement");
        }
        public ActionResult Delete(int id)
        {
            _announcementService.DeleteByID(id);
            return RedirectToAction("Index" , "Announcement");
        }
    }
}