using CMS.BLL.Abstract;
using CMS.MODEL.Entities;
using CMS.TOOLS.Contact;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.UI.MVC.Areas.BusinessStructure.Controllers.Department
{
    public class HRController : Controller
    {
        // GET: BusinessStructure/HR
        IEmployeesService _employeesService;
        IPetitionService _petitionService;
        IOpinionsService _opinionsService;
        IJobApplicationService _jobApplicationService;
        Petition petition;
        JobApplication ja;
        Employees emp;
        Mail mail;

        public HRController(IEmployeesService employeesService, IPetitionService petitionService, IOpinionsService opinionsService, IJobApplicationService jobApplicationService)
        {
            _employeesService = employeesService;
            _petitionService = petitionService;
            _opinionsService = opinionsService;
            _jobApplicationService = jobApplicationService;
            petition = new Petition();
            emp = new Employees();
            ja = new JobApplication();
            mail = new Mail();
        }
        public ActionResult Index()
        {
           
            ViewBag.TotalStaff = _employeesService.GetAll().Where(x=>x.IsActive == true).Count();
            ViewBag.HolidayTrue = _employeesService.GetAll().Where(x=>x.Holiday == true).Count();
            ViewBag.HolidayFalse = _employeesService.GetAll().Where(x=>x.Holiday == false).Count();
            ViewBag.PendingPetition = _petitionService.GetAll().Where(x=>x.Confirmation == TransactionStatus.Beklemede).Count();
            return View();
        }
        public ActionResult Staff()
        {
            return View(_employeesService.GetAll());
        }
        
        public ActionResult AddStaff()
        {
            ViewBag.Dn = Enum.GetNames(typeof(Departments)).ToList();
            ViewBag.Tn = Enum.GetNames(typeof(Title)).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(Employees emp)
        {         
            emp.IsActive = true;
            emp.ModifiedDate = DateTime.Now;
            emp.Holiday = false;
            _employeesService.Insert(emp);
            return RedirectToAction("Staff", "HR");
        }

        public ActionResult UpdateStaff(int id)
        {
            return View(_employeesService.Get(id));
        }

        [HttpPost]
        public ActionResult UpdateStaff(Employees emp)
        {
            var currentEmployees = _employeesService.Get(emp.Id);

            currentEmployees.TCKN = emp.TCKN;
            currentEmployees.FirstName = emp.FirstName;
            currentEmployees.LastName = emp.LastName;
            currentEmployees.Address = emp.Address;
            currentEmployees.Phone = emp.Phone;
            currentEmployees.EMail = emp.EMail;
            currentEmployees.Price = emp.Price;
            currentEmployees.Notes = emp.Notes;

            _employeesService.Update(currentEmployees);
            return RedirectToAction("Staff", "HR");
        }
        public ActionResult DeleteStaff(int Id)
        {
            _employeesService.DeleteByID(Id);
            return RedirectToAction("Staff","HR");
        }
        public ActionResult Petition()
        {
            return View(_petitionService.pendingPetition(TransactionStatus.Beklemede));
        }
        public ActionResult Opinions()
        {
            int kotu = Convert.ToInt32(_opinionsService.GetAll().Where(x => x.Bad == true).Count());
            int normal = Convert.ToInt32(_opinionsService.GetAll().Where(x => x.Normal == true).Count());
            int iyi = Convert.ToInt32(_opinionsService.GetAll().Where(x => x.Beautiful == true).Count());
            ViewBag.Kotu = kotu;
            ViewBag.Normal = normal;
            ViewBag.Iyi = iyi;
            if(kotu > normal && kotu > iyi)
            { 
                ViewBag.Ortalama = 0;
            }
            else if(normal > kotu && normal > iyi)
            {
                ViewBag.Ortalama = 1;
            }
            if(iyi > normal && iyi > kotu)
            {
                ViewBag.Ortalama = 2;
            }
            return View(_opinionsService.GetAll().ToList());
        }
        public ActionResult Recruitment() // Home için iş başvuruları açılacak 
        {
            return View(_jobApplicationService.GetAll());
        }
        public ActionResult ApproveRecruitment(int id) 
        {
            var currentJA = _jobApplicationService.Get(id);
            currentJA.Confirmation = TransactionStatus.Onaylandı;
            currentJA.ModifiedDate = DateTime.Now;
            _jobApplicationService.Update(currentJA);
            mail.GorusmeSonucu(ja.Email, ja.FirstName + " " + ja.LastName, ja.Confirmation);
            return RedirectToAction("Recruitment", "HR");
        }
        public ActionResult jectionRecruitment(int id) 
        {
            var currentJA = _jobApplicationService.Get(id);
            currentJA.Confirmation = TransactionStatus.Onaylanmadı;
            currentJA.ModifiedDate = DateTime.Now;
            _jobApplicationService.Update(currentJA);
            mail.GorusmeSonucu(ja.Email , ja.FirstName + " " + ja.LastName , ja.Confirmation);        
            return RedirectToAction("Recruitment", "HR");
        }

        public ActionResult PetitionApprove(int id)
        {
            petition = _petitionService.Get(id);
            petition.Confirmation = TransactionStatus.Onaylandı;
            petition.ModifiedDate = DateTime.Now;
            _petitionService.Update(petition);
           
            return RedirectToAction("Petition" , "HR");
        }

        public ActionResult PetitionRejection(int id)
        {
            petition = _petitionService.Get(id);
            petition.Confirmation = TransactionStatus.Onaylanmadı;
            petition.ModifiedDate = DateTime.Now;
            _petitionService.Update(petition);
            return RedirectToAction("Petition", "HR");
        }

    }
}