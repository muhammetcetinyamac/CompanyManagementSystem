using CMS.CORE.Entity;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MODEL.Entities
{
    public class JobApplication : BaseEntity
    {
        public string TCKN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CV { get; set; }
        public TransactionStatus Confirmation { get; set; }
    }
}
