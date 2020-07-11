using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework.Mapping
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            Property(x => x.Description).HasMaxLength(300);
            Property(x => x.ProductName).HasMaxLength(100).IsRequired();
        }
    }
}
