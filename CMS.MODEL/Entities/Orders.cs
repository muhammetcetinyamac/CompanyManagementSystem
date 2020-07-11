using CMS.CORE.Entity;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Orders: BaseEntity
    {
        public Orders()
        {
            Products = new HashSet<Product>();
        }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int ShipperID { get; set; }
        public OrderType OrdersType { get; set; }
        public int ProductID { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCountry { get; set; }
        public TransactionStatus Status { get; set; }


        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Employees Employee { get; set; }        
        public virtual Shippers Shipper { get; set; }
    }
}
