using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.MODEL.Enums
{
    public enum Departments
    {
        Admin = 1,
        [Display(Name = "İnsan Kaynakları")]
        HR = 2,
        [Display(Name = "İç Hizmetler")]
        InternalServices = 3,
        [Display(Name = "Pazarlama")]
        Marketing = 4,
        [Display(Name = "Üretim")]
        Production = 5,
        [Display(Name = "AR-GE")]
        ResearchDevelopment = 6,
        [Display(Name = "Satın Alma")]
        ThePurchasing = 7,
        [Display(Name = "Depo")]
        Warehouse = 8
    }
}