using AutoMapper;
using PagedList;
using Project.DAL;
using Project.DAL.Models;
using Project.Model;
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
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository _vehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
        }

        public async Task<IVehicleMakeDomainModel> GetIdVehicleMake(Guid id)
        {
            return await _vehicleMakeRepository.GetId(id);
        }

        public async Task<int> InsertVehicleMake(IVehicleMakeDomainModel entity)
        {
            return await _vehicleMakeRepository.Insert(entity);
        }

        public async Task<int> UpdateVehicleMake(IVehicleMakeDomainModel entity)
        {
            return await _vehicleMakeRepository.Update(entity);
        }

        public async Task<int> DeleteVehicleMake(IVehicleMakeDomainModel entity)
        {
            return await _vehicleMakeRepository.Delete(entity);
        }

        public async Task<IEnumerable<IVehicleMakeDomainModel>> GetAllVehicleMake()
        {
            return await _vehicleMakeRepository.GetAll();
        }
    }
}
