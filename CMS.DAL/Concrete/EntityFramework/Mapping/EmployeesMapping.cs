using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework.Mapping
{
    public class EmployeesMapping : EntityTypeConfiguration<Employees>
    {
        public EmployeesMapping()
        {
            
            Property(x => x.TCKN).HasMaxLength(11);
            Property(x => x.Phone).HasMaxLength(11);

        }
    }
}
