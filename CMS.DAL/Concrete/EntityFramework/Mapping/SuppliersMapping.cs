using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework.Mapping
{
    public class SuppliersMapping : EntityTypeConfiguration<Suppliers>
    {
        public SuppliersMapping()
        {
            Property(x => x.Phone).HasMaxLength(150).IsRequired();
            Property(x => x.CompanyName).HasMaxLength(150).IsRequired();
            Property(x => x.ContactTitle).HasMaxLength(50);
            Property(x => x.ContactName).HasMaxLength(50).IsRequired();
        }
    }
}
