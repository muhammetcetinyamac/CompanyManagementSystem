using CMS.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.UI.MVC.Areas.BusinessStructure.Controllers.Transactions
{
    public class WorkingStatusController : Controller
    {
        // GET: BusinessStructure/WorkingStatus
        IEmployeesService _employeesService;
        public WorkingStatusController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public ActionResult Index()
        {
           
            return View(_employeesService.Get(Convert.ToInt32(Session["UserId"])));
        }
    }
}