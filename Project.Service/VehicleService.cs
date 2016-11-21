using AutoMapper;
using PagedList;
using Project.DAL;
using Project.DAL.Models;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleService
    {
        private static VehicleService VehicleServices;
        private readonly VehicleContext Db;
        IPagedList VehiclesList;
        int pageSize = 3;

        private VehicleService()
        {
            Db = new VehicleContext();
        }

        public static VehicleService GetInstance
        {
            get
            {
                if (VehicleServices == null)
                {
                    VehicleServices = new VehicleService();
                }
                return VehicleServices;
            }
        }

        public void CreateVehicleMake(VehicleMakeDomainModel vehicleMake)
        {
            Db.VehicleMakes.Add(Mapper.Map<VehicleMake>(vehicleMake));
            Db.SaveChanges();
        }

        public void CreateVehicleModel(VehicleModelDomainModel vehicleModel)
        {
            Db.VehicleModels.Add(Mapper.Map<VehicleModel>(vehicleModel));
            Db.SaveChanges();
        }

        public VehicleMakeDomainModel FindVehicleMake(Guid? id)
        {
            return Mapper.Map<VehicleMake, VehicleMakeDomainModel>(Db.VehicleMakes.Find(id));
        }

        public VehicleModelDomainModel FindVehicleModel(Guid? id)
        {
            return Mapper.Map<VehicleModel, VehicleModelDomainModel>(Db.VehicleModels.Find(id));
        }

        public void EditVehicleMake(VehicleMakeDomainModel viewVehicleMake)
        {
            VehicleMake vehicleMakes = Db.VehicleMakes.Find(viewVehicleMake.VehicleMakeId);
            Mapper.Map(viewVehicleMake, vehicleMakes);
            Db.SaveChanges();
        }

        public void EditVehicleModel(VehicleModelDomainModel viewVehicleModel)
        {
            VehicleModel vehicleModels = Db.VehicleModels.Find(viewVehicleModel.VehicleModelId);
            Mapper.Map(viewVehicleModel, vehicleModels);
            Db.SaveChanges();
        }

        public void DeleteVehicleMake(Guid? id)
        {
            VehicleMake vehicleMakes = Db.VehicleMakes.Find(id);
            Db.VehicleMakes.Remove(vehicleMakes);
            Db.SaveChanges();
        }

        public void DeleteVehicleModel(Guid? id)
        {
            VehicleModel vehicleModels = Db.VehicleModels.Find(id);
            Db.VehicleModels.Remove(vehicleModels);
            Db.SaveChanges();
        }

        public IPagedList SearchSortVehicleMake(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = (page ?? 1);
            var vehicles = Db.VehicleMakes.AsQueryable();

            if (searchString != null)
            {
                page = 1;
                vehicles = Db.VehicleMakes.Where(x => x.VehicleMakeName.Contains(searchString));
            }
            else
            {
                searchString = currentFilter;
                vehicles = Db.VehicleMakes.AsQueryable();

            }
            switch (sortOrder)
            {
                case "Name":
                    VehiclesList = Mapper.Map<IEnumerable<VehicleMakeDomainModel>>(vehicles.OrderBy(x => x.VehicleMakeName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Name_desc":
                    VehiclesList = Mapper.Map<IEnumerable<VehicleMakeDomainModel>>(vehicles.OrderByDescending(x => x.VehicleMakeName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Abrv:":
                    VehiclesList = Mapper.Map<IEnumerable<VehicleMakeDomainModel>>(vehicles.OrderBy(x => x.VehicleMakeAbrv)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Abrv_desc:":
                    VehiclesList = Mapper.Map<IEnumerable<VehicleMakeDomainModel>>(vehicles.OrderByDescending(x => x.VehicleMakeAbrv)).ToPagedList(pageNumber, pageSize);
                    break;
                default:
                    VehiclesList = Mapper.Map<IEnumerable<VehicleMakeDomainModel>>(vehicles.OrderBy(x => x.VehicleMakeName)).ToPagedList(pageNumber, pageSize);
                    break;
            }
            return VehiclesList;
        }

        public IPagedList SearchSortVehicleModel(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageNumber = (page ?? 1);
            var vehicles = Db.VehicleModels.AsQueryable();

            if (searchString != null)
            {
                page = 1;
                vehicles = Db.VehicleModels.Where(x => x.VehicleMake.VehicleMakeName.Contains(searchString) || x.VehicleModelName.Contains(searchString));
            }
            else
            {
                searchString = currentFilter;
                vehicles = Db.VehicleModels.AsQueryable();
            }

            switch (sortOrder)
            {
                case "Name":
                    VehiclesList = Mapper.Map<IEnumerable<VehicleModelDomainModel>>(vehicles.OrderBy(x => x.VehicleMake.VehicleMakeName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Name_desc":
                    VehiclesList = Mapper.Map<IEnumerable<VehicleModelDomainModel>>(vehicles.OrderByDescending(x => x.VehicleMake.VehicleMakeName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Model":
                    VehiclesList = Mapper.Map<IEnumerable<VehicleModelDomainModel>>(vehicles.OrderBy(x => x.VehicleModelName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Model_desc":
                    VehiclesList = Mapper.Map<IEnumerable<VehicleModelDomainModel>>(vehicles.OrderByDescending(x => x.VehicleModelName)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Abrv":
                    VehiclesList = Mapper.Map<IEnumerable<VehicleModelDomainModel>>(vehicles.OrderBy(x => x.VehicleModelAbrv)).ToPagedList(pageNumber, pageSize);
                    break;
                case "Abrv_desc":
                    VehiclesList = Mapper.Map<IEnumerable<VehicleModelDomainModel>>(vehicles.OrderByDescending(x => x.VehicleModelAbrv)).ToPagedList(pageNumber, pageSize);
                    break;
                default:
                    VehiclesList = Mapper.Map<IEnumerable<VehicleModelDomainModel>>(vehicles.OrderBy(x => x.VehicleModelName)).ToPagedList(pageNumber, pageSize);
                    break;
            }
            return VehiclesList;
        }


    }
}
