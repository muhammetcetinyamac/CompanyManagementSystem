using CMS.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class VehicleFleet : BaseEntity
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Location { get; set; }
        public int EmployeesId { get; set; }
        public virtual Employees Employees { get; set; }
    }
}
