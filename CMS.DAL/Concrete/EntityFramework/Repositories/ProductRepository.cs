using CMS.CORE.DAL.EntityFramework;
using CMS.MODEL.Entities;
using CMS.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework.Repositories
{
    public class ProductRepository:EFRepositoryBase<Product,CMSDbContext>,IProductDAL
    {
    }
}
