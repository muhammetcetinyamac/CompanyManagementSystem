using CMS.CORE.Entity;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Materials = new HashSet<Material>();
        }
        public int MaterialsId { get; set; }
        public int CategoryId { get; set; }

        public string ProductName { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Picture { get; set; }
        public TransactionStatus Status { get; set; }


        public virtual ICollection<Material> Materials { get; set; }
        public virtual Category Category { get; set; }


    }
}
