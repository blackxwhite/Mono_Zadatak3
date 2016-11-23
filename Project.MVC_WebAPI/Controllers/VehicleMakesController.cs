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
using Project.DAL;
using Project.DAL.Models;
using Project.Service.Common;

namespace Project.MVC_WebAPI.Controllers
{
    public class VehicleMakesController : ApiController
    {

        private IVehicleMakeService _vehicleMakeService;

        public VehicleMakesController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }

        private VehicleContext db = new VehicleContext();

        // GET: api/VehicleMakes
        public IQueryable<VehicleMake> GetVehicleMakes()
        {
            return db.VehicleMakes;
        }

        // GET: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult GetVehicleMake(Guid id)
        {
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(vehicleMake);
        }

        // PUT: api/VehicleMakes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleMake(Guid id, VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleMake.VehicleMakeId)
            {
                return BadRequest();
            }

            db.Entry(vehicleMake).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleMakeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VehicleMakes
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult PostVehicleMake(VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleMakes.Add(vehicleMake);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleMake.VehicleMakeId }, vehicleMake);
        }

        // DELETE: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult DeleteVehicleMake(Guid id)
        {
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            db.VehicleMakes.Remove(vehicleMake);
            db.SaveChanges();

            return Ok(vehicleMake);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleMakeExists(Guid id)
        {
            return db.VehicleMakes.Count(e => e.VehicleMakeId == id) > 0;
        }
    }
}