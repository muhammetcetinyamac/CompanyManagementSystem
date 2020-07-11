using CMS.BLL.Abstract;
using CMS.MODEL.Entities;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.UI.MVC.Areas.BusinessStructure.Controllers.Department
{
    public class MarketingController : Controller
    {
        // GET: BusinessStructure/Marketing
        IOrdersService _orderservice;
        IAnnouncementService _announcementService;
        ICustomersService _customersService;
        IProductService _productService;
        IShippersService _shippersService;
        
        public MarketingController(IOrdersService orderservice, IAnnouncementService announcementService, ICustomersService customersService, IProductService productService, IShippersService shippersService)
        {
            _productService = productService;
            _customersService = customersService;
            _orderservice = orderservice;
            _announcementService = announcementService;
            _shippersService = shippersService;            
        }
        public ActionResult Index()
        {
            ViewBag.TotalOrder = _orderservice.GetAll().Where(x => x.IsActive == true).Count();
            ViewBag.ReadyOrder = _orderservice.GetAll().Where(x => x.Status == TransactionStatus.Üretim).Count();
            ViewBag.CompletedOrder = _orderservice.GetAll().Where(x => x.Status == TransactionStatus.Tamamlandı).Count();
            ViewBag.Duyurular = _announcementService.GetAll().Count();
            return View();
        }
        public ActionResult Order() // siparişlerin durumları yazılacak
        {          
            return View(_orderservice.GetAll().ToList());
        } 
        public ActionResult SubmitToProduction(int id) // siparişlerin durumları yazılacak
        {
            var currentOrder = _orderservice.Get(id);
            currentOrder.Status = TransactionStatus.Üretim;
            _orderservice.Update(currentOrder);
            return RedirectToAction("Order","Marketing");
        }
        public ActionResult SubmitToCustomer(int id) // siparişlerin durumları yazılacak
        {
            var currentOrder = _orderservice.Get(id);
            currentOrder.Status = TransactionStatus.Tamamlandı;
            _orderservice.Update(currentOrder);
            return RedirectToAction("Order", "Marketing");
        }
        public ActionResult AddOrder()
        {
           
            ViewBag.GetAllCustomers = _customersService.GetAll();
            ViewBag.GetAllProducts = _productService.GetAll();
            ViewBag.GetAllShippers = _shippersService.GetAll();
            ViewBag.OrderType = Enum.GetNames(typeof(OrderType));
            return View();
        }
     
        [HttpPost]
        public ActionResult AddOrder(Orders orders)
        {
            Product p = new Product();
            p = _productService.Get(orders.ProductID);
            orders.EmployeeID = Convert.ToInt32(Session["UserId"]);
            orders.Status = TransactionStatus.Beklemede;
            orders.IsActive = true;
            orders.ModifiedDate = DateTime.Now;
           
            var currentOrder = _orderservice.Get(Convert.ToInt32(Session["OrderId"]));

            
           // currentOrder.Products.Add(p);
            _orderservice.Insert(orders);
            return RedirectToAction("Order", "Marketing");
        }

        
        public ActionResult UpdateOrder(int id)
        {
            var currentOrder = _orderservice.Get(id);
            ViewBag.GetOrder = currentOrder;
            ViewBag.GetProduct = _productService.Get(currentOrder.ProductID);
            return View();
        }
        [HttpPost]
        public ActionResult UpdateOrder(Orders orders)
        {
            var currentOrders = _orderservice.Get(orders.Id);          
            currentOrders.ModifiedDate = DateTime.Now;
            currentOrders.IsActive = false;
            _orderservice.Update(currentOrders);
            return RedirectToAction("Order", "Marketing");
        }

        public ActionResult DeleteOrder(int id)
        {
            _orderservice.DeleteByID(id);
            return RedirectToAction("Order", "Marketing");
        }

        public ActionResult FinishedOrder()
        {
            return View(_orderservice.GetAll().Where(x=>x.Status == TransactionStatus.Tamamlandı).ToList());
        }
        public ActionResult ExpectedOrder()
        {
            return View(_orderservice.GetAll().Where(x=>x.Status == TransactionStatus.Üretim).ToList());
        }
        public ActionResult Customers()
        {
            return View(_customersService.GetAll().ToList());
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customers customers)
        {
            customers.ModifiedDate = DateTime.Now;
            customers.IsActive = true;
            _customersService.Insert(customers);
            return RedirectToAction("Customers", "Marketing");
        }
        public ActionResult DeleteCustomer(int id)
        {
            _customersService.DeleteByID(id);
            return RedirectToAction("Customers", "Marketing");
        }
        public ActionResult UpdateCustomer(int id)
        {
            return View(_customersService.Get(id));
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customers customers)
        {
            var currentCustomers = _customersService.Get(customers.Id);
            currentCustomers.Address = customers.Address;
            currentCustomers.CompanyName = customers.CompanyName;
            currentCustomers.ContactName = customers.ContactName;
            currentCustomers.ContactTitle = customers.ContactTitle;
            currentCustomers.Mail = customers.Mail;
            currentCustomers.Phone = customers.Phone;
            currentCustomers.ModifiedDate = DateTime.Now;
            currentCustomers.IsActive = true;
            _customersService.Update(currentCustomers);
            return RedirectToAction("Customers", "Marketing");
        }
        public ActionResult Shipper()
        {
            return View(_shippersService.GetAll().ToList());
        }
        public ActionResult AddShipper()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddShipper(Shippers shippers) 
        {
            shippers.IsActive = true;
            shippers.ModifiedDate = DateTime.Now;
            //shippers.OrdersId = 0;
            _shippersService.Insert(shippers);
            return RedirectToAction("Shipper", "Marketing");
        }
        public ActionResult DeleteShipper(int id)
        {
            _shippersService.DeleteByID(id);
            return RedirectToAction("Shipper", "Marketing");
        }
        public ActionResult UpdateShipper(int id) 
        {
            return View(_shippersService.Get(id));
        } 
      
        
        [HttpPost]
        public ActionResult UpdateShipper(Shippers shippers)
        {
            var currentShipper = _shippersService.Get(shippers.Id);
            currentShipper.CompanyName = shippers.CompanyName;
            currentShipper.Phone = shippers.Phone;
            currentShipper.Address = shippers.Address;
            currentShipper.ModifiedDate = DateTime.Now;
            currentShipper.IsActive = true;
            _shippersService.Update(currentShipper);
            return RedirectToAction("Shipper", "Marketing");
        }

      
       

    }
}