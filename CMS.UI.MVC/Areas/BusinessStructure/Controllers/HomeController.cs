using CMS.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.UI.MVC.Areas.BusinessStructure.Controllers
{
    public class HomeController : Controller
    {
        // GET: BusinessStructure/Home
        IAnnouncementService _announcementService;
        public HomeController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        public ActionResult Index()
        {
            return View(_announcementService.GetAll().ToList());
        }
    }
}