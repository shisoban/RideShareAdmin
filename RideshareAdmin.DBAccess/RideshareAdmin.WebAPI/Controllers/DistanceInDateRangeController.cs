using BusinessEntities;
using RideshareAdmin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RideshareAdmin.WebAPI.Controllers
{
    public class DistanceInDateRangeController : ApiController
    {
        public HttpResponseMessage Post([FromBody]DateRange dateRange) {

            IRidehistoriesService ridedetail = new RidehistoriesService();

            DistanceInDateRange distancetotal = ridedetail.GetTotalDistancefilterbyDateRange(dateRange.start_date, dateRange.end_date);

            if (distancetotal != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, distancetotal);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error in calculating distance");

        }
    }
}
