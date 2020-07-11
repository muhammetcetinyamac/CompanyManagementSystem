using CMS.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Customers : BaseEntity
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int OrdersId { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        
    }

}
