using CMS.BLL.Abstract;
using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.UI.MVC.Areas.BusinessStructure.Controllers.Department
{
    public class ThePurchasingController : Controller
    {
        // GET: BusinessStructure/ThePurchasing
        // IncomingOrder (Gelen Sipariş) -  Suppliers - AddSuppliers
        ISuppliersService _suppliersService;
        IMaterialService _materialService;
        public ThePurchasingController(ISuppliersService suppliersService, IMaterialService materialService)
        {
            _suppliersService = suppliersService;
            _materialService = materialService;

        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MaterialList()
        {
            return View(_materialService.GetAll().Where(x=>x.IsActive == true).ToList());
        }
        public ActionResult AddMaterialStock(int id)
        {
            return View(_materialService.Get(id));
        }
        
        [HttpPost]
        public ActionResult AddMaterialStock(Material material)
        {
            var currentMaterial = _materialService.Get(material.Id);
            currentMaterial.UnitsInStock += material.UnitsInStock;
            currentMaterial.ModifiedDate = DateTime.Now;
            _materialService.Update(currentMaterial);
            return RedirectToAction("MaterialList");
        }
        public ActionResult UpdateMaterialStock(int id)
        {       
            return View(_materialService.Get(id));
        }
        [HttpPost]
        public ActionResult UpdateMaterialStock(Material material)
        {
            var currentMaterial = _materialService.Get(material.Id);
            currentMaterial.UnitsInStock = material.UnitsInStock;
            currentMaterial.ModifiedDate = DateTime.Now;
            _materialService.Update(currentMaterial);
            return RedirectToAction("MaterialList");
        }
        public ActionResult IncomingOrder()
        {
            return View();
        }

        //*********///////////********/////////**********///////////*********///
        public ActionResult Suppliers()
        {
            return View(_suppliersService.GetAll());
        }
        public ActionResult AddSuppliers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSuppliers(Suppliers suppliers)
        {
            suppliers.IsActive = true;
            suppliers.ModifiedDate = DateTime.Now;
            _suppliersService.Insert(suppliers);
            return RedirectToAction("Suppliers");
        }
        public ActionResult UpdateSuppliers(int id)
        {
            return View(_suppliersService.Get(id));
        }
        [HttpPost]
        public ActionResult UpdateSuppliers(Suppliers suppliers)
        {
            var currentSuppliers = _suppliersService.Get(suppliers.Id);
            currentSuppliers.CompanyName = suppliers.CompanyName;
            currentSuppliers.ContactName = suppliers.ContactName;
            currentSuppliers.ContactTitle = suppliers.ContactTitle;
            currentSuppliers.Address = suppliers.Address;
            currentSuppliers.Phone = suppliers.Phone;
            currentSuppliers.Fax = suppliers.Fax;
            currentSuppliers.HomePage = suppliers.HomePage;
            currentSuppliers.ModifiedDate = DateTime.Now;
            _suppliersService.Update(currentSuppliers);
            return RedirectToAction("Suppliers");
        }
        public ActionResult DeleteSuppliers(int id)
        {
            _suppliersService.DeleteByID(id);
            return RedirectToAction("Suppliers");
        }
        //*********///////////********/////////**********///////////*********///
    }
}