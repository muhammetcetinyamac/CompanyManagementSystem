using CMS.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Opinions : BaseEntity
    {
        
        public bool Bad { get; set; }
        public bool Normal { get; set; }
        public bool Beautiful { get; set; }
        public int EmployeesId { get; set; }

        public virtual Employees Employees { get; set; }
    }
}
