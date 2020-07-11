using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.MODEL.Enums
{
    public enum Title
    {
        [Display(Name = "Müdür")]
        Manager,
        [Display(Name = "Müdür Yardımcısı")]
        ExecutiveAssistant,
        [Display(Name = "Birim Sorumlusu")]
        Chef,
        [Display(Name = "Personel")]
        Staff
    }
}