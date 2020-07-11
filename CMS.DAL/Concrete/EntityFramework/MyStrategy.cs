using CMS.MODEL.Entities;
using CMS.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework
{
    public class MyStrategy : DropCreateDatabaseIfModelChanges<CMSDbContext>
    {

        protected override void Seed(CMSDbContext context)
        {
            //base.Seed(context);

            var emp = new List<Employees>
                  {
                  new Employees { Address = "İstanbul", BirthDate=DateTime.Now, CreatedDate = DateTime.Now,FirstName="Muhammed", LastName = "Çetinyamaç" , Gender = "Erkek",HireDate=DateTime.Now, ModifiedDate = DateTime.Now, Notes="Patron" , Orders = null , Password= "1234", Phone="05439529712" , Title=Title.Manager , Department=Departments.HR, IsActive = true, TCKN="12345678999"},

                   new Employees { Address = "Ankara", BirthDate=DateTime.Now, CreatedDate = DateTime.Now,FirstName="Ahmet", LastName = "Mehmet" , Gender = "Erkek",HireDate=DateTime.Now, ModifiedDate = DateTime.Now, Notes="Bilgisayar Oyunlarını sever" , Orders = null , Password= "1", Phone="05159527512" , Title=Title.Staff , Department=Departments.Production, IsActive = true, TCKN="98765432119"}

                     
                  };       
            context.Employees.AddRange(emp);
            context.SaveChanges();


        }
    }
}
