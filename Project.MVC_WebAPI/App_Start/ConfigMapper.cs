using AutoMapper;
using Project.DAL.Models;
using Project.Model;
using Project.Model.Common;
using Project.MVC_WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC_WebAPI.App_Start
{
    public class ConfigMapper
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VehicleMake, VehicleMakeDomainModel>().ReverseMap();
                cfg.CreateMap<VehicleMakeDomainModel, VehicleMakeViewModel>().ReverseMap();
                cfg.CreateMap<VehicleMakeDomainModel, IVehicleMakeDomainModel>().ReverseMap();
                cfg.CreateMap<IVehicleMakeDomainModel, VehicleMakeDomainModel>().ReverseMap();

                cfg.CreateMap<VehicleModel, VehicleModelDomainModel>().ReverseMap();
                cfg.CreateMap<VehicleModelDomainModel, VehicleModelViewModel>().ReverseMap();
                cfg.CreateMap<VehicleModelDomainModel, IVehicleModelDomainModel>().ReverseMap();
                cfg.CreateMap<IVehicleModelDomainModel, VehicleModelDomainModel>().ReverseMap();
            });
        }
    }
}