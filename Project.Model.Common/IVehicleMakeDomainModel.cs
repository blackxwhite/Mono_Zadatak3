using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Common
{
    public interface IVehicleMakeDomainModel
    {
        Guid VehicleMakeId { get; set; }
        string VehicleMakeName { get; set; }
        string VehicleMakeAbrv { get; set; }
        ICollection<IVehicleModelDomainModel> VehicleModel { get; set; }
    }
}
