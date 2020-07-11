using CMS.DAL.Abstract;
using CMS.DAL.Concrete.EntityFramework.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.BLL.loC
{
    public class CMSDALModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnnouncementDAL>().To<AnnouncementRepository>();
            Bind<ICategoryDAL>().To<CategoryRepository>();
            Bind<ICustomersDAL>().To<CustomersRepository>();
            Bind<IEmployeesDAL>().To<EmployeesRepository>();
            Bind<IMaterialDAL>().To<MaterialRepository>();
            Bind<IOpinionsDAL>().To<OpinionsRepository>();
            Bind<IOrdersDAL>().To<OrdersRepository>();
            Bind<IPetitionDAL>().To<PetitionRepository>();
            Bind<IProductDAL>().To<ProductRepository>();
            Bind<IReportDAL>().To<ReportRepository>();
            Bind<IShippersDAL>().To<ShippersRepository>();
            Bind<ISuppliersDAL>().To<SuppliersRepository>();
            Bind<ITasksDAL>().To<TasksRepository>();
            Bind<IVehicleFleetDAL>().To<VehicleFleetRepository>();
            Bind<IWarehouseDAL>().To<WarehouseRepository>();
            Bind<IJobApplicationDAL>().To<JobApplicationsRepository>();
        }
    }
}
