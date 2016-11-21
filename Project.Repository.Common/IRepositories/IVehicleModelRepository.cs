using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common.IRepositories
{
    public interface IVehicleModelRepository
    {
        Task<IVehicleModelDomainModel> GetId(Guid id);
        Task<int> Insert(IVehicleModelDomainModel entity);
        Task<int> Update(IVehicleModelDomainModel entity);
        Task<int> Delete(IVehicleModelDomainModel entity);
        Task<IEnumerable<IVehicleModelDomainModel>> GetAll();
    }
}
