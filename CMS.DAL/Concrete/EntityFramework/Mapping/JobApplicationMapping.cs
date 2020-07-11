using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework.Mapping
{
    public class JobApplicationMapping : EntityTypeConfiguration<JobApplication>
    {
        public JobApplicationMapping()
        {
            Property(x => x.Email).HasMaxLength(50);
            Property(x => x.FirstName).HasMaxLength(50);
            Property(x => x.LastName).HasMaxLength(50);
            Property(x => x.Phone).HasMaxLength(50);
            Property(x => x.TCKN).HasMaxLength(50);
        }
    }
}
