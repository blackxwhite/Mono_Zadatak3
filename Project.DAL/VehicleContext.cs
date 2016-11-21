using Project.DAL.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Project.DAL.Common;

namespace Project.DAL
{
    public class VehicleContext : DbContext, IVehicleContext
    {
        public VehicleContext() : base("VehicleContext") { }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
