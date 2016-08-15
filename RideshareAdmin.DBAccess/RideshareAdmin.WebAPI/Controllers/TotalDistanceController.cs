using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RideshareAdmin.Services;
using BusinessEntities;

namespace RideshareAdmin.WebAPI.Controllers
{
    [RoutePrefix("api/TotalDistance")]
    public class TotalDistanceController : ApiController
    {
        private readonly IRidehistoriesService _ridehistoriesService;

        public TotalDistanceController(IRidehistoriesService ridehistory)
        {
            _ridehistoriesService = ridehistory;
        }
        public HttpResponseMessage GetTotalDistance()
        {
            TotalDistance totalDistance = _ridehistoriesService.GetTotalDistance();
            if (totalDistance != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, totalDistance);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error in calculating distance");

        }

        // GET api/TotalDistance/emission
        [Route("emission")]
        public HttpResponseMessage GetEmission()
        {
            Emission emission = _ridehistoriesService.GetEmission();
            if (emission != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, emission);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error in calculating distance");

        }

        // GET api/TotalDistance/Totalemission
        [Route("Totalemission")]
        public HttpResponseMessage GetTotalemission()
        {
            Emission emission = _ridehistoriesService.GetTotalEmission();
            if (emission != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, emission);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error in calculating distance");
        }
    }
}
