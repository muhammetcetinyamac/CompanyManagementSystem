using CMS.BLL.Abstract;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.UI.MVC.Areas.BusinessStructure.Controllers.Department
{
    public class WarehouseController : Controller
    {
        // GET: BusinessStructure/Warehouse
        //Materials - Products
        IOrdersService _orderservice;
        IMaterialService _materialService;
        IEmployeesService _employeesService;
        public WarehouseController(IOrdersService orderservice, IMaterialService materialService , IEmployeesService employeesService)
        {
            _orderservice = orderservice;
            _materialService = materialService;
            _employeesService = employeesService;
           
        }
        public ActionResult Index()
        {
            ViewBag.TotalOrder = _orderservice.GetAll().Where(x => x.Status == TransactionStatus.Depo).Count();
            ViewBag.TotalEmployee = _employeesService.GetAll().Where(x=>x.Department == Departments.Warehouse).Count();
            
            return View();
        }

        public ActionResult Orders()
        {
            return View(_orderservice.GetAll().Where(x => x.Status == TransactionStatus.Depo).ToList());
        }
        public ActionResult SendProduct(int id)
        {
            var currentOrder = _orderservice.Get(id);
            currentOrder.Status = TransactionStatus.Pazarlama;
            currentOrder.ModifiedDate = DateTime.Now;
            _orderservice.Update(currentOrder);
            return RedirectToAction("Orders");
        }


    }
}