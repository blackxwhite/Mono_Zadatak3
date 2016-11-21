using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class VehicleMakeDomainModel : IVehicleMakeDomainModel
    {
        public Guid VehicleMakeId { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleMakeAbrv { get; set; }

        public ICollection<VehicleModelDomainModel> VehicleModel { get; set; }
    }
}
