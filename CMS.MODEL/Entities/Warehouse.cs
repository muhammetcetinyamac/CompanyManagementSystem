using CMS.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
