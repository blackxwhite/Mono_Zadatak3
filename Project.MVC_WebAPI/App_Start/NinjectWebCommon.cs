[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Project.MVC_WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Project.MVC_WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace Project.MVC_WebAPI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using DAL;
    using DAL.Common;
    using DAL.Common.Models;
    using DAL.Models;
    using Model.Common;
    using Model;
    using Repository.Common.IRepositories;
    using Repository.Repositories;

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
            kernel.Bind<IVehicleContext>().To<VehicleContext>().InRequestScope();
            kernel.Bind<IVehicleMake>().To<VehicleMake>().InRequestScope();
            kernel.Bind<IVehicleModel>().To<VehicleModel>().InRequestScope();
            kernel.Bind<IVehicleMakeDomainModel>().To<VehicleMakeDomainModel>().InRequestScope();
            kernel.Bind<IVehicleModelDomainModel>().To<VehicleModelDomainModel>().InRequestScope();
            kernel.Bind<IGenericRepository>().To<GenericRepository>().InRequestScope();
            kernel.Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>().InRequestScope();
            kernel.Bind<IVehicleModelRepository>().To<VehicleModelRepository>().InRequestScope();
        }
    }
}