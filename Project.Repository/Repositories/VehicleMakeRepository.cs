using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository.Common.IRepositories;
using Project.Model.Common;
using AutoMapper;
using Project.Model;
using Project.DAL.Models;

namespace Project.Repository.Repositories
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly IGenericRepository _genericRepository;

        public VehicleMakeRepository(IGenericRepository genericRepository)
        {
            this._genericRepository = genericRepository;
        }

        public async Task<IVehicleMakeDomainModel> GetId(Guid id)
        {
            return Mapper.Map<VehicleMakeDomainModel>(await _genericRepository.GetId<VehicleMake>(id));
        }

        public async Task<int> Insert(IVehicleMakeDomainModel entity)
        {
            return await _genericRepository.Insert(Mapper.Map<VehicleMake>(entity));
        }

        public async Task<int> Update(IVehicleMakeDomainModel entity)
        {
            return await _genericRepository.Update(Mapper.Map<VehicleMake>(entity));
        }

        public async Task<int> Delete(IVehicleMakeDomainModel entity)
        {
            return await _genericRepository.Delete(Mapper.Map<VehicleMake>(entity));
        }

        public async Task<IEnumerable<IVehicleMakeDomainModel>> GetAll()
        {
            return Mapper.Map<IEnumerable<IVehicleMakeDomainModel>>(await _genericRepository.GetAll<VehicleMake>());
        }
    }
}
