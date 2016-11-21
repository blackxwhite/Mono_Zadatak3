using AutoMapper;
using Project.DAL.Models;
using Project.Model;
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
                cfg.CreateMap<VehicleModel, VehicleModelDomainModel>().ReverseMap();
                cfg.CreateMap<VehicleMake, VehicleMakeDomainModel>().ReverseMap();
            });
        }
    }
}