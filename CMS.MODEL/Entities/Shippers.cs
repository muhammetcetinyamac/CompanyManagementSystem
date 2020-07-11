using CMS.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Shippers: BaseEntity
    {
        public Shippers()
        {
            Orders = new HashSet<Orders>();
        }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public int OrdersId { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
