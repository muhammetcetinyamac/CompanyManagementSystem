using CMS.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Suppliers: BaseEntity
    {
        public Suppliers()
        {
            Materials = new HashSet<Material>();
        }
        
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

        public int MaterialId { get; set; }

        public virtual ICollection<Material> Materials { get; set; }
    }
}
