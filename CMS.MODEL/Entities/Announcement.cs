using CMS.CORE.Entity;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Announcement : BaseEntity
    {
        public int EmployeesID { get; set; }
        public string Content { get; set; }
        public Departments Departments { get; set; }
        public virtual Employees Employees { get; set; }
    }
}
