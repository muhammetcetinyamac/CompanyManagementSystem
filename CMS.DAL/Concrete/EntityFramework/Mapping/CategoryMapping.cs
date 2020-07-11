using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework.Mapping
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            Property(x => x.CategoryName).HasMaxLength(150).IsRequired();
            Property(x => x.Description).HasMaxLength(500);
        }
    }
}
