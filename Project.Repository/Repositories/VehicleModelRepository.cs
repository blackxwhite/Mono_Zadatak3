using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository.Common.IRepositories;
using Project.Model.Common;
using Project.DAL.Models;
using Project.Model;
using AutoMapper;

namespace Project.Repository.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private IGenericRepository _genericRepository;

        public VehicleModelRepository(IGenericRepository genericRepository)
        {
            this._genericRepository = genericRepository;
        }

        public async Task<IVehicleModelDomainModel> GetId(Guid id)
        {
            return Mapper.Map<VehicleModelDomainModel>(await _genericRepository.GetId<VehicleModel>(id));
        }

        public async Task<int> Insert(IVehicleModelDomainModel entity)
        {
            return await _genericRepository.Insert(Mapper.Map<VehicleModel>(entity));
        }

        public async Task<int> Update(IVehicleModelDomainModel entity)
        {
            return await _genericRepository.Update(Mapper.Map<VehicleModel>(entity));
        }

        public async Task<int> Delete(IVehicleModelDomainModel entity)
        {
            return await _genericRepository.Delete(Mapper.Map<VehicleModel>(entity));
        }

        public async Task<IEnumerable<IVehicleModelDomainModel>> GetAll()
        {
            return Mapper.Map<IEnumerable<IVehicleModelDomainModel>>(await _genericRepository.GetAll<VehicleModel>());
        }
    }
}
