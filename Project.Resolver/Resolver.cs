using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Project.DAL.Common;
using Project.DAL;
using Project.DAL.Common.Models;
using Project.DAL.Models;
using Project.Model.Common;
using Project.Model;
using Project.Repository.Common.IRepositories;
using Project.Repository.Repositories;
using Project.Repository.Common;
using Project.Repository;
using Project.Service.Common;
using Project.Service;

namespace Project.Resolver
{
    public class Resolver : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleContext>().To<VehicleContext>();
            Bind<IVehicleMake>().To<VehicleMake>();
            Bind<IVehicleModel>().To<VehicleModel>();
            Bind<IVehicleMakeDomainModel>().To<VehicleMakeDomainModel>();
            Bind<IVehicleModelDomainModel>().To<VehicleModelDomainModel>();
            Bind<IGenericRepository>().To<GenericRepository>();
            Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>();
            Bind<IVehicleModelRepository>().To<VehicleModelRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IVehicleMakeService>().To<VehicleMakeService>();
            Bind<IVehicleModelService>().To<VehicleModelService>();
        }
    }
}
