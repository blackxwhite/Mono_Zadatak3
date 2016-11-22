using Project.Model.Common;
using Project.Repository.Common.IRepositories;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelRepository _vehicleModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleMakeRepository)
        {
            _vehicleModelRepository = vehicleMakeRepository;
        }

        public async Task<IVehicleModelDomainModel> GetIdVehicleModel(Guid id)
        {
            return await _vehicleModelRepository.GetId(id);
        }

        public async Task<int> InsertVehicleModel(IVehicleModelDomainModel entity)
        {
            return await _vehicleModelRepository.Insert(entity);
        }

        public async Task<int> UpdateVehicleModel(IVehicleModelDomainModel entity)
        {
            return await _vehicleModelRepository.Update(entity);
        }

        public async Task<int> DeleteVehicleModel(IVehicleModelDomainModel entity)
        {
            return await _vehicleModelRepository.Delete(entity);
        }

        public async Task<IEnumerable<IVehicleModelDomainModel>> GetAllVehicleModel()
        {
            return await _vehicleModelRepository.GetAll();
        }
    }
}
