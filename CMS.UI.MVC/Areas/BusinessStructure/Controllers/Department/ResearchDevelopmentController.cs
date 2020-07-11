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
    public class ResearchDevelopmentController : Controller
    {
        // GET: BusinessStructure/ResearchDevelopment
        //AddProduct - AddMateriel - Product - Materiel - ViewProduct
        IEmployeesService _employeesService;
        IProductService _productService;
        IOrdersService _ordersService;
        ICategoryService _categoryService;
        public ResearchDevelopmentController(IProductService productService,IEmployeesService employeesService, IOrdersService ordersService, ICategoryService categoryService)
        {
            _productService = productService;
            _employeesService = employeesService;
            _ordersService = ordersService;
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            ViewBag.TotalProduction = _ordersService.GetAll().Where(x => x.Status == TransactionStatus.Beklemede).Count();
            ViewBag.PreparedOrders = _ordersService.GetAll().Where(x => x.Status == TransactionStatus.Üretim).Count();
            ViewBag.WaitingforMaterial = _ordersService.GetAll().Where(x => x.Status == TransactionStatus.MalzemeBekliyor).Count();
            ViewBag.Working = _employeesService.GetAll().Where(x => x.Department == Departments.ResearchDevelopment).Count();
            return View();
        }
       
        public ActionResult Product()
        {
            return View(_productService.GetAll().ToList());
        }
        //***************************************************************************************
       
        //***************************************************************************************
        public ActionResult ViewProduct(int id)
        {
            ViewBag.GetProduct = _productService.Get(id);
            return View();
        }
        //***************************************************************************************
        public ActionResult AddProduct()
        {
            ViewBag.GetCategories = _categoryService.GetAll().Where(x=>x.IsActive == true).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            product.IsActive = true;
            product.ModifiedDate = DateTime.Now;
            _productService.Insert(product);
            return RedirectToAction("Product", "ResearchDevelopment");
        }
        public ActionResult UpdateProduct(int id)
        {
            ViewBag.GetCategories = _categoryService.GetAll().Where(x => x.IsActive == true).ToList();
            return View(_productService.Get(id));
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var currentProduct = _productService.Get(product.Id);
            currentProduct.IsActive = true;
            currentProduct.ModifiedDate = DateTime.Now;
            return RedirectToAction("Product", "ResearchDevelopment");
        }
        public ActionResult DeleteProduct(int id)
        {
            _productService.DeleteByID(id);
            return RedirectToAction("Product", "ResearchDevelopment");
        }
        //-****************************************-//
       

        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category cat)
        {
            cat.ModifiedDate = DateTime.Now;
            cat.IsActive = true;
            _categoryService.Insert(cat);
            return RedirectToAction("Category", "ResearchDevelopment");
        }
        public ActionResult UpdateCategory(int id)
        {
            return View(_categoryService.Get(id));
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category cat)
        {
            var currentCategory = _categoryService.Get(cat.Id);
            currentCategory.ModifiedDate = DateTime.Now;
            currentCategory.CategoryName = cat.CategoryName;
            currentCategory.Description = cat.Description;
            _categoryService.Update(currentCategory);
            return RedirectToAction("Category", "ResearchDevelopment");
        }
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteByID(id);
            return RedirectToAction("Category", "ResearchDevelopment");
        }
        public ActionResult Category()
        {
            return View(_categoryService.GetAll().ToList());
        }

    }
}