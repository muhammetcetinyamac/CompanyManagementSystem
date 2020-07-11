using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Enums
{
    public enum TransactionStatus
    {
        [Display(Name = "İptal")]
        İptal,
        [Display(Name = "Beklemede")]
        Beklemede,
        [Display(Name = "Tamamlandı")]
        Tamamlandı,
        [Display(Name = "Üretimde")]
        Üretim,
        [Display(Name = "Pazarlamada")]
        Pazarlama,
        [Display(Name = "Depoda")]
        Depo,
        [Display(Name = "Onaylandı")]
        Onaylandı,
        [Display(Name = "Onaylanmadı")]
        Onaylanmadı,
        [Display(Name = "Malzeme Bekliyor")]
        MalzemeBekliyor
        
    }
}
