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
        private readonly IRidehistoriesService _ridehistoriesService=new RidehistoriesService();
        public HttpResponseMessage GetTotalDistance()
        {
           // IRidehistoriesService ridedetail = new RidehistoriesService();

            TotalDistance totalDistance = _ridehistoriesService.GetTotalDistance();
            if (totalDistance != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, totalDistance);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error in calculating distance");

        }

        [Route("emission")]
        public HttpResponseMessage GetEmission()
        {
             //IRidehistoriesService ridedetail = new RidehistoriesService();

            Emission emission = _ridehistoriesService.GetEmission();
            if (emission != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, emission);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error in calculating distance");

        }



        [Route("Totalemission")]
        public HttpResponseMessage GetTotalemission()
        {
            //IRidehistoriesService ridedetail = new RidehistoriesService();

            Emission emission = _ridehistoriesService.GetTotalEmission();
            if (emission != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, emission);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error in calculating distance");

        }
    }
}
