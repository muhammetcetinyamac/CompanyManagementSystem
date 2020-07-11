using CMS.BLL.Abstract;
using CMS.DAL.Abstract;
using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL.Concrete
{
    public class ProductService : IProductService
    {
        IProductDAL _productDAL;
        public ProductService(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }
        public void Delete(Product entity)
        {
            _productDAL.Remove(entity);
        }

        public void DeleteByID(int entityID)
        {
            Delete(Get(entityID));
        }

        public Product Get(int entityID)
        {
            return _productDAL.Get(a => a.Id == entityID);
        }

        public ICollection<Product> GetAll()
        {
            return _productDAL.GetAll();
        }

        public void Insert(Product entity)
        {
            _productDAL.Add(entity);
        }

        public void Update(Product entity)
        {
            _productDAL.Update(entity);
        }
    }
}
