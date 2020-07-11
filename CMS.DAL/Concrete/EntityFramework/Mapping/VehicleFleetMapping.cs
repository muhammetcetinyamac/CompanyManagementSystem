using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework.Mapping
{

    public class VehicleFleetMapping : EntityTypeConfiguration<VehicleFleet>
    {
        public VehicleFleetMapping()
        {
            Property(x => x.Model).HasMaxLength(150);
            Property(x => x.Location).HasMaxLength(150);
            Property(x => x.Type).HasMaxLength(150);
        }
    }
}
