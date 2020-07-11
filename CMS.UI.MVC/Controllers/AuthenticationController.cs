using CMS.BLL.Abstract;
using CMS.MODEL.Entities;
using CMS.TOOLS.Contact;
using CMS.UI.MVC.Areas.BusinessStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CMS.UI.MVC.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        IEmployeesService _employeesService;
        Mail mail;
        Employees emp;
        public AuthenticationController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //  [ValidateAntiForgeryToken]        
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                Employees currentUser = _employeesService.GetUserByLogin(loginViewModel.TCKN, loginViewModel.Password);

                if (currentUser != null && currentUser.IsActive)
                {
                    FormsAuthentication.SetAuthCookie(currentUser.TCKN, true);
                    Session["EMail"] = currentUser.EMail;
                    Session["Name"] = currentUser.FirstName + " " + currentUser.LastName;
                    Session["UserId"] = currentUser.Id;
                    Session["Department"] = currentUser.Department;
                    Session["Title"] = currentUser.Title;
                    Session["UserNameLetter"] = Convert.ToChar(currentUser.FirstName.Substring(0, 1));

                    //Session["loginmodel"] = loginViewModel;

                    //Session["loginmodel"] as LoginViewModel;

                    return RedirectToAction("Index", currentUser.Department.ToString(), new { area = "BusinessStructure" });
                }
                else
                {
                    ViewBag.Error = "TC Kimlik Numarası veya Şifre Hatalı.";
                }
            }
            else
            {
                ViewBag.Error = "TC Kimlik Numarası veya Şifre Hatalı.";
            }
            return View();

        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Authentication", new { area = "" });
        }

        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            mail = new Mail();

            var currentEmp = _employeesService.GetUserEmail(email);
            mail.SendMail("Şifre İşlemleri", email, "Merhaba Sayın " + currentEmp.FirstName + " " + currentEmp.LastName + "\n" + "Şifreniz : " + currentEmp.Password);
            return View();
        }
    }
}