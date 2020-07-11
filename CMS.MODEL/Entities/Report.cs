using CMS.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Report : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Attachments { get; set; }
        public int EmployeesId { get; set; }

        public virtual Employees Employees { get; set; }
    }
}
