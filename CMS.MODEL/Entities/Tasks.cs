using CMS.CORE.Entity;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Tasks : BaseEntity
    {      
        public string TaskName { get; set; }
        public int CommissionedBy { get; set; }
        public int EmployeesId { get; set; }
        public string JobDescription { get; set; }
        public TransactionStatus Confirmation { get; set; }

        //map
        public virtual Employees Employees { get; set; }
    }
}
