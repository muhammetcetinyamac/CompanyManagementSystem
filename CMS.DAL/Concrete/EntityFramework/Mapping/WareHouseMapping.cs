﻿using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework.Mapping
{
    public class WareHouseMapping : EntityTypeConfiguration<Warehouse>
    {
        public WareHouseMapping()
        {
            Property(x => x.Name).HasMaxLength(150).IsRequired();
           
        }
    }
}
