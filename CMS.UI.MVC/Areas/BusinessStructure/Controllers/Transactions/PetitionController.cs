using CMS.BLL.Abstract;
using CMS.MODEL.Entities;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.UI.MVC.Areas.BusinessStructure.Controllers.Actions
{
    public class PetitionController : Controller
    {
        // GET: BusinessStructure/Petition
        IPetitionService _petitionService;
        Petition _petition;
        public PetitionController(IPetitionService petitionService)
        {
            _petitionService = petitionService;
            _petition = new Petition();
        }
        public ActionResult Index()
        {
            return View(_petitionService.GetAll().Where(x => x.EmployeesId == Convert.ToInt32(Session["UserId"])).ToList());
        }
        public ActionResult New()
        {
            ViewBag.PTn = Enum.GetNames(typeof(PetitionType)).ToList();       
            return View();
        }

        [HttpPost]
        public ActionResult New(Petition petition)
        {           
            petition.EmployeesId = Convert.ToInt32(Session["UserId"]);
            petition.ModifiedDate = DateTime.Now;
            petition.IsActive = true;
            petition.Confirmation = TransactionStatus.Beklemede;
            _petitionService.Insert(petition);
            return RedirectToAction("Index","Petition");
        }
        
        public ActionResult Delete(int Id)
        {
            _petitionService.DeleteByID(Id);
            return RedirectToAction("Index", "Petition");
        }
        public ActionResult Update(int Id)
        {
            return View(_petitionService.Get(Id));
        }

        [HttpPost]
        public ActionResult Update(Petition petition)
        {
            var currentPetition = _petitionService.Get(petition.Id);
            currentPetition.Content = petition.Content;
            currentPetition.RelatedInstitution = petition.RelatedInstitution;
            currentPetition.Type = petition.Type;
            currentPetition.ModifiedDate = DateTime.Now;           
            _petitionService.Update(currentPetition);
            return RedirectToAction("Index", "Petition");
        }
    }
}