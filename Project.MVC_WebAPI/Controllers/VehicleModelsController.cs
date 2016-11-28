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
    [RoutePrefix("api/VehicleModels")]
    public class VehicleModelsController : ApiController
    {
        private IVehicleModelService _vehicleModelService;

        public VehicleModelsController(IVehicleModelService vehicleModelService)
        {
            _vehicleModelService = vehicleModelService;
        }

        //private VehicleContext db = new VehicleContext();

        // GET: api/VehicleModels
        [HttpGet]
        [Route("getvehiclemodels")]
        public async Task<HttpResponseMessage> GetVehicleModels()
        {
            var vehicleModels = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(await _vehicleModelService.GetAllVehicleModel());
            return Request.CreateResponse(HttpStatusCode.OK, vehicleModels);
        }

        // GET: api/VehicleModels/5
        [ResponseType(typeof(VehicleModelViewModel))]
        public async Task<HttpResponseMessage> GetVehicleModel(Guid id)
        {
            var vehicleModel = Mapper.Map<VehicleModelViewModel>(await _vehicleModelService.GetIdVehicleModel(id));
            if (vehicleModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, vehicleModel);
            }

            return Request.CreateResponse(HttpStatusCode.OK, vehicleModel);
        }

        // PUT: api/VehicleModels/5
        [ResponseType(typeof(void))]
        public async Task<HttpResponseMessage> PutVehicleModel(Guid id, VehicleModelViewModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleModels = await _vehicleModelService.UpdateVehicleModel(Mapper.Map<VehicleModelDomainModel>(vehicleModel));
                return Request.CreateResponse(HttpStatusCode.OK, vehicleModel);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError, "error, can't update");
        }

        // POST: api/VehicleModels
        [ResponseType(typeof(VehicleModelViewModel))]
        public async Task<HttpResponseMessage> PostVehicleModel(VehicleModelViewModel vehicleModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var vehicleModels = await _vehicleModelService.InsertVehicleModel(Mapper.Map<VehicleModelDomainModel>(vehicleModel));
                    return Request.CreateResponse(HttpStatusCode.OK, vehicleModels);
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "error, can't add");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "error, can't add" + ex);
            }
            //return CreatedAtRoute("DefaultApi", new { id = vehicleModel.VehicleModelId }, vehicleModel);
        }

        // DELETE: api/VehicleModels/5
        [ResponseType(typeof(VehicleModelViewModel))]
        public async Task<HttpResponseMessage> DeleteVehicleModel(Guid id)
        {
            var vehicleModel = Mapper.Map<VehicleModelViewModel>(await _vehicleModelService.GetIdVehicleModel(id));
            if (vehicleModel == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "vehicle model not found");
            }

            var removeVehicleModel = await _vehicleModelService.DeleteVehicleModel(Mapper.Map<VehicleModelDomainModel>(vehicleModel));
            return Request.CreateResponse(HttpStatusCode.OK, removeVehicleModel);
        }

        //private bool VehicleModelExists(Guid id)
        //{
        //    return db.VehicleModels.Count(e => e.VehicleModelId == id) > 0;
        //}
    }
}