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
    public class InternalServicesController : Controller
    {
        // GET: BusinessStructure/InternalServices
        IVehicleFleetService _vehicleFleetService;
        IEmployeesService _employeesService;
        ITasksService _tasksService;
        IAnnouncementService _announcementService;
        IMaterialService _materialService;
        public InternalServicesController(IVehicleFleetService vehicleFleetService , IEmployeesService employeesService, ITasksService tasksService, IAnnouncementService announcementService, IMaterialService materialService)
        {
            _vehicleFleetService = vehicleFleetService;
            _employeesService = employeesService;
            _tasksService = tasksService;
            _announcementService = announcementService;
            _materialService = materialService;
        }
        public ActionResult Index()
        {
            ViewBag.TotalTasks = _tasksService.GetAll().Where(x => x.IsActive == true).Count();
            ViewBag.TotalVehicle = _vehicleFleetService.GetAll().Count();
            ViewBag.TotalDebit = _vehicleFleetService.GetAll().Where(x => x.EmployeesId != 0).Count();
            ViewBag.Duyurular = _announcementService.GetAll().Count();
            return View();
        }
        public ActionResult AddEmployment()
        {
            return View(_employeesService.GetAll().Where(x=>x.Title != Title.Manager).ToList());
        }

        [HttpPost]
        public ActionResult AddEmployment(Tasks tasks)
        {
            tasks.CommissionedBy = Convert.ToInt32(Session["UserId"]);
            tasks.IsActive = true;
            tasks.Confirmation = TransactionStatus.Beklemede;
            tasks.ModifiedDate = DateTime.Now;
            _tasksService.Insert(tasks);
            return RedirectToAction("Index", "InternalServices");
        }
        public ActionResult VehicleFleet()
        {
            return View(_vehicleFleetService.GetAll());
        }
        public ActionResult AddVehicle()
        {
            ViewBag.GetAllEmp = _employeesService.GetAll().Where(x=>x.VehicleFleetId == 0).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddVehicle(VehicleFleet vf)
        {
            vf.ModifiedDate = DateTime.Now;
            vf.IsActive = true;           
            _vehicleFleetService.Insert(vf);
            return RedirectToAction("VehicleFleet", "InternalServices");
        }

        public ActionResult UpdateVehicle(int id)
        {
            ViewBag.GetAllEmp = _employeesService.GetAll().Where(x => x.VehicleFleetId == 0).ToList();
            return View(_vehicleFleetService.Get(id));
        }

        [HttpPost]
        public ActionResult UpdateVehicle(VehicleFleet vf)
        {
            var vehicle = _vehicleFleetService.Get(vf.Id);
            vehicle.Brand = vf.Brand;
            vehicle.Employees = vf.Employees;
            vehicle.EmployeesId = vf.EmployeesId;
            vehicle.Type = vf.Brand;
            vehicle.Model = vf.Brand;
            vehicle.Location = vf.Brand;
            vehicle.IsActive = vf.IsActive;
            vehicle.CreatedDate = vf.CreatedDate;
            vehicle.ModifiedDate = DateTime.Now;
            _vehicleFleetService.Update(vehicle);
                return RedirectToAction("VehicleFleet", "InternalServices");
        }

        public ActionResult DeleteVehicle(int id)
        {
            _vehicleFleetService.DeleteByID(id);
            return RedirectToAction("VehicleFleet", "InternalServices");
        }

        public ActionResult AllTasks()
        {
            
            return View(_tasksService.GetAll().ToList());
        }


        public ActionResult Materiel()
        {
            return View(_materialService.GetAll().ToList());
        }
        public ActionResult AddMateriel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMateriel(Material material)
        {
            material.Discontinued = false;
            material.IsActive = true;
            material.UnitsInStock = 0;
            material.ModifiedDate = DateTime.Now;
            material.SupplierID = 0;
            material.ProductID = 0;
            _materialService.Insert(material);
            return RedirectToAction("Materiel", "InternalServices");
        }
        public ActionResult UpdateMateriel(int id)
        {
            return View(_materialService.Get(id));
        }
        [HttpPost]
        public ActionResult UpdateMateriel(Material material)
        {
            var currentMaterial = _materialService.Get(material.Id);
            currentMaterial.MaterialName = material.MaterialName;
            currentMaterial.UnitPrice = material.UnitPrice;
            currentMaterial.ModifiedDate = DateTime.Now;
            _materialService.Update(currentMaterial);
            return RedirectToAction("Materiel", "InternalServices");
        }
        public ActionResult DeleteMaterial(int id)
        {
            return View(_materialService.Get(id));
        }
        //-****************************************-//
        



    }
}