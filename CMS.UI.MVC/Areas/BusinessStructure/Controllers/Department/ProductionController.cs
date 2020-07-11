using CMS.BLL.Abstract;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.UI.MVC.Areas.BusinessStructure.Controllers.Department
{
    public class ProductionController : Controller
    {
        // GET: BusinessStructure/Production
        //IncomingOrder - DeliveredOrder - PendingOrder 
        IProductService _productService;
        IOrdersService _ordersService;
        public ProductionController(IProductService productService , IOrdersService ordersService)
        {
            _productService = productService;
            _ordersService = ordersService;
        }
        public ActionResult Index()
        {
            ViewBag.WaitProduct = _ordersService.GetAll().Where(x=>x.Status == TransactionStatus.Üretim).Count();
            ViewBag.FinishProduct = _ordersService.GetAll().Where(x => x.Status == TransactionStatus.Depo).Count();
            return View();
        }
        public ActionResult IncomingOrder()
        {
            return View(_ordersService.GetAll().Where(x=>x.Status == TransactionStatus.Üretim).ToList());
        }
        public ActionResult DeliveredOrder()
        {
            return View(_ordersService.GetAll().Where(x => x.Status == TransactionStatus.Depo).ToList());
        }

        public ActionResult PendingOrder()
        {
            return View(_ordersService.GetAll().Where(x => x.Status == TransactionStatus.Beklemede).ToList());
        }

        public ActionResult FinishOrder(int id)
        {
            var currentOrder = _ordersService.Get(id);
            currentOrder.Status = TransactionStatus.Depo;
            _ordersService.Update(currentOrder);
            return View("IncomingOrder" , "Production");
        }

    }
}