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
    public class RideListInDateRangeController : ApiController
    {
        // Post method for ridelist date range
        public HttpResponseMessage Post([FromBody]DateRange dateRange)
        {
            IRidehistoriesService ridedetail = new RidehistoriesService();

            IEnumerable<RideHistoriesEntity> rideHistoryInDateRange = ridedetail.RideListInDateRange(dateRange.start_date, dateRange.end_date);

            if (rideHistoryInDateRange.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, rideHistoryInDateRange);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error in calculating distance");

        }
    }
}
