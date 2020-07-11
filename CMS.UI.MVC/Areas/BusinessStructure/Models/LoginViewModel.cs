using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.UI.MVC.Areas.BusinessStructure.Models
{
    public class LoginViewModel
    {
        public string TCKN { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Department { get; set; }
        public char UserNameLetter { get; set; }
    }
}