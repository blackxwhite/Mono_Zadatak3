using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Common.Models
{
    public interface IVehicleMake
    {
        Guid VehicleMakeId { get; set; }
        string VehicleMakeName { get; set; }
        string VehicleMakeAbrv { get; set; }
    }
}
