using AutoMapper;
using Project.DAL.Models;
using Project.Model;
using Project.Model.Common;
using Project.MVC.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC.WebAPI.App_Start
{
    public class ConfigMapper
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VehicleMakeDomainModel, VehicleMakeViewModel>().ReverseMap();
                cfg.CreateMap<VehicleMakeDomainModel, IVehicleMakeDomainModel>().ReverseMap();
                cfg.CreateMap<IVehicleMakeDomainModel, VehicleMakeDomainModel>().ReverseMap();

                cfg.CreateMap<VehicleModelDomainModel, VehicleModelViewModel>().ReverseMap();
                cfg.CreateMap<VehicleModelDomainModel, IVehicleModelDomainModel>().ReverseMap();
                cfg.CreateMap<IVehicleModelDomainModel, VehicleModelDomainModel>().ReverseMap();
                //cfg.CreateMap<VehicleModel, VehicleModelDomainModel>().ReverseMap();
                //cfg.CreateMap<VehicleMake, VehicleMakeDomainModel>().ReverseMap();
            });
        }
    }
}