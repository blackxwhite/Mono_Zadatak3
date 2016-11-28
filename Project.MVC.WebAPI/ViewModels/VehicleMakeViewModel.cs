using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC.WebAPI.ViewModels
{
    public class VehicleMakeViewModel
    {
        public Guid VehicleMakeId { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleMakeAbrv { get; set; }

        public ICollection<VehicleModelViewModel> VehicleModel { get; set; }
    }
}