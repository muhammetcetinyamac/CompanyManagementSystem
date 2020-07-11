using CMS.BLL.Abstract;
using CMS.MODEL.Entities;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        IAnnouncementService _announcementService;
        IJobApplicationService _jobApplicationService;
        public HomeController(IAnnouncementService announcementService, IJobApplicationService jobApplicationService)
        {
            _announcementService = announcementService;
            _jobApplicationService = jobApplicationService;
        }
       
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult HomeAnnouncement()
        {
            return View(_announcementService.GetLastTenAnnouncement().ToList());
        }
        public ActionResult JobApplication()
        {
            return View(_announcementService.GetLastTenAnnouncement().ToList());
        }
        [HttpPost]
        public ActionResult JobApplication(JobApplication ja)
        {
            ja.ModifiedDate = DateTime.Now;
            ja.IsActive = true;
            ja.Confirmation = TransactionStatus.Beklemede;
            _jobApplicationService.Insert(ja);
            return View(_announcementService.GetLastTenAnnouncement().ToList());
        }
        public ActionResult ReturnJobApplication()
        {
            return View();
        }
    }
}