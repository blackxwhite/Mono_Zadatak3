using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Common.Models
{
    public interface IVehicleModel
    {
        Guid VehicleModelId { get; set; }
        Guid VehicleMakeId { get; set; }
        string VehicleModelName { get; set; }
        string VehicleModelAbrv { get; set; }
    }
}
