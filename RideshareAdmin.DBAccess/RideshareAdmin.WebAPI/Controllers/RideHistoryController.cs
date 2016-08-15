using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RideshareAdmin.DBAccess.Models;
using RideshareAdmin.Services;
using BusinessEntities;
using System.Web.Script.Serialization;

namespace RideshareAdmin.WebAPI.Controllers
{
    [RoutePrefix("api/rideHistory")]
    public class RideHistoryController : ApiController
    {        
        private readonly IRidehistoriesService _ridehistoriesService;

        public RideHistoryController()
        {
            _ridehistoriesService = new RidehistoriesService();
        }

        // GET api/rideHistory/id
        public HttpResponseMessage Get(string id)
        {
            var ridehistory = _ridehistoriesService.Get(id);
            if (ridehistory.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, ridehistory);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, " ridehistory not found for provided username");
        }

        // GET api/rideHistory/
        public HttpResponseMessage GetAll()
        {
            var rideHistories = _ridehistoriesService.GetAll();

            if (rideHistories.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, rideHistories);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No result found.");
            
        }

        // GET api/rideHistory/RidesCount
        [Route("RidesCount")]
        public HttpResponseMessage GetRidesCount()
        {
            RidesCount ridesCount = _ridehistoriesService.GetRidesCount();
            //List<RidesCount> list = new List<RidesCount>();
            //list.Add(ridesCount);
            return Request.CreateResponse(HttpStatusCode.OK, ridesCount);

        }

        // GET api/rideHistory/RidesCountByMonth
        [Route("RidesCountByMonth")]
        public HttpResponseMessage GetRidesCountByMonth()
        {
            IRidehistoriesService ridetotal = new RidehistoriesService();

            RideHistoryByCurrentMonth totalrides = ridetotal.GetTotalRidesfilterbyCurrentMonth();
            if (totalrides != null)
            {
               return Request.CreateResponse(HttpStatusCode.OK, totalrides);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error in calculating distance");

        }

        // GET api/rideHistory/RidesByLocation
        [Route("RidesByLocation")]
        public HttpResponseMessage GetAllByLocation()
        {
            var rideHistories = _ridehistoriesService.GetRidesByLocation().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, rideHistories);

        }

        // GET api/rideHistory/NoOfRidesByDrivers
        [Route("NoOfRidesByDrivers")]
        public HttpResponseMessage GetRideCountByDrivers()
        {           
            var rideHistories = _ridehistoriesService.GetRideCountByDrivers().ToList();            
            return Request.CreateResponse(HttpStatusCode.OK, rideHistories);

        }

        // GET api/rideHistory/DistanceByMonth
        [Route("DistanceByMonth")]
        public HttpResponseMessage GetDistanceByMonth()
        {
            var rideHistories = _ridehistoriesService.GetDistanceByMonth().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, rideHistories);

        }

        // GET api/rideHistory/NoOfRidesByUser
        [Route("NoOfRidesByUser")]
        public HttpResponseMessage GetRidesCountByUser()
        {
            var rideHistories = _ridehistoriesService.GetTopRiders().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, rideHistories);

        }
    }
}

