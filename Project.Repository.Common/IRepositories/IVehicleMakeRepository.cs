using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common.IRepositories
{
    public interface IVehicleMakeRepository
    {
        Task<IVehicleMakeDomainModel> GetId(Guid id);
        Task<int> Insert(IVehicleMakeDomainModel entity);
        Task<int> Update(IVehicleMakeDomainModel entity);
        Task<int> Delete(IVehicleMakeDomainModel entity);
        Task<IEnumerable<IVehicleMakeDomainModel>> GetAll();
    }
}
