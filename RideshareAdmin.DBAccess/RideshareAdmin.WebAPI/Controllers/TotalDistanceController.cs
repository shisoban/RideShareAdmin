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
    public class TotalDistanceController : ApiController
    {
        public HttpResponseMessage Post()
        {
            IRidehistoriesService ridedetail = new RidehistoriesService();

            TotalDistance totalDistance = ridedetail.GetTotalDistance();
            if (totalDistance != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, totalDistance);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error in calculating distance");

        }

        }
}
