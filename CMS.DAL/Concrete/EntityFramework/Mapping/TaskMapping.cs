using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework.Mapping
{

    public class TaskMapping : EntityTypeConfiguration<Tasks>
    {
        public TaskMapping()
        {
            Property(x => x.TaskName).HasMaxLength(150).IsRequired();
            Property(x => x.JobDescription).HasMaxLength(500).IsRequired();
        }
    }

}
