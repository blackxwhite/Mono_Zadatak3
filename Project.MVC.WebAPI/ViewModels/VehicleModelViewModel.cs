using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC.WebAPI.ViewModels
{
    public class VehicleModelViewModel
    {
        public Guid VehicleModelId { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string VehicleModelName { get; set; }
        public string VehicleModelAbrv { get; set; }
        public VehicleMakeViewModel VehicleMake { get; set; }
    }
}