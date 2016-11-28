using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Project.Service.Common;
using System.Threading.Tasks;
using AutoMapper;
using Project.MVC_WebAPI.ViewModels;
using Project.Model;

namespace Project.MVC_WebAPI.Controllers
{
    [RoutePrefix("api/VehicleMake")]
    public class VehicleMakesController : ApiController
    {

        private IVehicleMakeService _vehicleMakeService;

        public VehicleMakesController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }

        //private VehicleContext db = new VehicleContext();

        // GET: api/VehicleMakes
        [HttpGet]
        [Route("getall")]
        public async Task<HttpResponseMessage> GetVehicleMakes()
        {
            var vehicleMakes = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(await _vehicleMakeService.GetAllVehicleMake());
            return Request.CreateResponse(HttpStatusCode.OK, vehicleMakes);
        }

        // GET: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMakeViewModel))]
        //[HttpGet]
        public async Task<HttpResponseMessage> GetVehicleMake(Guid id)
        {
            var vehicleMake = Mapper.Map<VehicleMakeViewModel>(await _vehicleMakeService.GetIdVehicleMake(id));
            if (vehicleMake == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, vehicleMake);
            }

            return Request.CreateResponse(HttpStatusCode.OK, vehicleMake);
        }

        // PUT: api/VehicleMakes/5
        [ResponseType(typeof(void))]
        public async Task<HttpResponseMessage> PutVehicleMake(Guid id, VehicleMakeViewModel vehicleMake)
        {
            if (ModelState.IsValid)
            {
                var vehicleMakes = await _vehicleMakeService.UpdateVehicleMake(Mapper.Map<VehicleMakeDomainModel>(vehicleMake));
                return Request.CreateResponse(HttpStatusCode.OK, vehicleMakes);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "error, can't update");
        }

        // POST: api/VehicleMakes
        [ResponseType(typeof(VehicleMakeViewModel))]
        public async Task<HttpResponseMessage> PostVehicleMake(VehicleMakeViewModel vehicleMake)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var vehicleMakes = await _vehicleMakeService.InsertVehicleMake(Mapper.Map<VehicleMakeDomainModel>(vehicleMake));
                    return Request.CreateResponse(HttpStatusCode.OK, vehicleMakes);
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "error, can't add");
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "error, can't add" + ex);
            }
            //return CreatedAtRoute("DefaultApi", new { id = vehicleMake.VehicleMakeId }, vehicleMake);
        }

        // DELETE: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMakeViewModel))]
        public async Task<HttpResponseMessage> DeleteVehicleMake(Guid id)
        {
            var vehicleMake = Mapper.Map<VehicleMakeViewModel>(await _vehicleMakeService.GetIdVehicleMake(id));

            if (vehicleMake == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "vehicle maker not found");
            }
            
            var removeVehicleMake = await _vehicleMakeService.DeleteVehicleMake(Mapper.Map<VehicleMakeDomainModel>(vehicleMake));
            return Request.CreateResponse(HttpStatusCode.OK, removeVehicleMake);
        }

        //private bool VehicleMakeExists(Guid id)
        //{
        //    return db.VehicleMakes.Count(e => e.VehicleMakeId == id) > 0;
        //}
    }
}