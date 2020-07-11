[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CMS.UI.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(CMS.UI.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace CMS.UI.MVC.App_Start
{
    using System;
    using System.Web;
    using CMS.BLL.Abstract;
    using CMS.BLL.Concrete;
    using CMS.BLL.loC;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAnnouncementService>().To<AnnouncementService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICustomersService>().To<CustomersService>();
            kernel.Bind<IEmployeesService>().To<EmployeesService>();
            kernel.Bind<IMaterialService>().To<MaterialService>();
            kernel.Bind<IOpinionsService>().To<OpinionsService>();
            kernel.Bind<IOrdersService>().To<OrdersService>();
            kernel.Bind<IPetitionService>().To<PetitionService>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IReportService>().To<ReportService>();
            kernel.Bind<IShippersService>().To<ShippersService>();
            kernel.Bind<ISuppliersService>().To<SuppliersService>();           
            kernel.Bind<ITasksService>().To<TasksService>();           
            kernel.Bind<IVehicleFleetService>().To<VehicleFleetService>();           
            kernel.Bind<IWarehouseService>().To<WarehouseService>();
            kernel.Bind<IWarehouseService>().To<WarehouseService>();
            kernel.Bind<IJobApplicationService>().To<JobApplicationService>();
            kernel.Load<CMSDALModule>();
        }        
    }
}
