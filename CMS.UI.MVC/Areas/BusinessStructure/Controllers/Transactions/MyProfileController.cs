using CMS.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.UI.MVC.Areas.BusinessStructure.Controllers.Transactions
{
    public class MyProfileController : Controller
    {
        // GET: BusinessStructure/MyProfile
        IEmployeesService _employeesService;
        public MyProfileController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        public ActionResult Index()
        {
            return View(_employeesService.Get(Convert.ToInt32(Session["UserId"])));
        }
    }
}