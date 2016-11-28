using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.MVC_WebAPI.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("test")]
        public HttpResponseMessage GetAllVehicleMakes()
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, "ispis");
        }
    }
}
