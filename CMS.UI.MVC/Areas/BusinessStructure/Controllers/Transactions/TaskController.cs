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
    public class TaskController : Controller
    {
        // GET: BusinessStructure/Task
        ITasksService _tasksService;
        IEmployeesService _employeesService;
        Tasks tsk;
        Employees emp;
        public TaskController(ITasksService tasksService, IEmployeesService employeesService)
        {
            _employeesService = employeesService;
            _tasksService = tasksService;
            tsk = new Tasks();
            emp = new Employees();
        }
        public ActionResult Index()
        {
            //return View(_tasksService.GetAll().Where(x => x.EmployeesId == Convert.ToInt32(Session["UserId"])));
            return View(_tasksService.GetAll().Where(x => x.EmployeesId == Convert.ToInt32(Session["UserId"])).ToList());
        }

        public ActionResult MissionCompleted(int id)
        {
            var currentTasks = _tasksService.Get(id);
            currentTasks.JobDescription += " Görev "+ currentTasks.Employees.FirstName + " " + currentTasks.Employees.LastName+" Tarafından Yapılmıştır.";
            currentTasks.Confirmation = TransactionStatus.Tamamlandı;
            currentTasks.IsActive = false;
            _tasksService.Update(currentTasks);
            return RedirectToAction("Index","Task");
        }


        public ActionResult MissionFailed(int id)
        {
            
            var currentTasks = _tasksService.Get(id);
            currentTasks.JobDescription += "\n" +currentTasks.Employees.FirstName + " " +currentTasks.Employees.LastName + " Tarafından Reddedildi";
            currentTasks.IsActive = true;
            currentTasks.Confirmation = TransactionStatus.Onaylanmadı;
            
            _tasksService.Update(currentTasks);
            return RedirectToAction("Index", "Task");
        }


    }
}