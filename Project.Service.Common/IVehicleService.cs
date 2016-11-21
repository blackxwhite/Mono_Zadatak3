using PagedList;
using Project.DAL.Models;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleService
    {
        void CreateVehicleMake(VehicleMakeDomainModel VehicleMake);
        void CreateVehicleModel(VehicleModelDomainModel VehicleModel);
        VehicleMakeDomainModel FindVehicleMake(Guid? id);
        VehicleModelDomainModel FindVehicleModel(Guid? id);
        void EditVehicleMake(VehicleMakeDomainModel VehicleMake);
        void EditVehicleModel(VehicleModelDomainModel VehicleModel);
        void DeleteVehicleMake(Guid? id);
        void DeleteVehicleModel(Guid? id);
        IPagedList SearchSortVehicleMake(string sortOrder, string currentFilter, string searchString, int? page);
        IPagedList SearchSortVehicleModel(string sortOrder, string currentFilter, string searchString, int? page);
        List<VehicleMake> getAll();
    }
}
