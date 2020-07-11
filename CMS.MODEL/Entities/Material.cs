using CMS.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Material: BaseEntity
    {
        public Material()
        {
            Products = new HashSet<Product>();
        }
        public string MaterialName { get; set; }
        public int SupplierID { get; set; }
        public int ProductID { get; set; }
        public byte[] Picture { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int AmountUsed { get; set; }
        public bool Discontinued { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Suppliers> Suppliers { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
