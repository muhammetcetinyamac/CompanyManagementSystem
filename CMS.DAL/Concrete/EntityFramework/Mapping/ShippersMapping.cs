﻿using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework.Mapping
{
    public class ShippersMapping : EntityTypeConfiguration<Shippers>
    {
        public ShippersMapping()
        {
            Property(x => x.CompanyName).HasMaxLength(150).IsRequired();
            Property(x => x.Phone).HasMaxLength(11).IsRequired();
        }
    }
}
