using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IVehicleModelDomainModel> GetIdVehicleModel(Guid id);
        Task<int> InsertVehicleModel(IVehicleModelDomainModel entity);
        Task<int> UpdateVehicleModel(IVehicleModelDomainModel entity);
        Task<int> DeleteVehicleModel(IVehicleModelDomainModel entity);
        Task<IEnumerable<IVehicleModelDomainModel>> GetAllVehicleModel();
    }
}
