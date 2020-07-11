using CMS.CORE.Entity;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class Petition : BaseEntity
    {
        public PetitionType Type { get; set; }
        public string RelatedInstitution { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }
        public int EmployeesId { get; set; }
        public string Attachments { get; set; }
        public TransactionStatus Confirmation { get; set; }

        //map
        public virtual Employees Employees { get; set; }
    }
}
