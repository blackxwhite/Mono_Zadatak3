using PagedList;
using Project.DAL.Models;
using Project.Model;
using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IVehicleMakeDomainModel> GetIdVehicleMake(Guid id);
        Task<int> InsertVehicleMake(IVehicleMakeDomainModel entity);
        Task<int> UpdateVehicleMake(IVehicleMakeDomainModel entity);
        Task<int> DeleteVehicleMake(IVehicleMakeDomainModel entity);
        Task<IEnumerable<IVehicleMakeDomainModel>> GetAllVehicleMake();

    }
}
