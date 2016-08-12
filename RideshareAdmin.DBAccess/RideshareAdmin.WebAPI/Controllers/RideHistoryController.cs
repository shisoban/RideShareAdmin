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
        //private readonly ICoordinateService _usercoordinateService;
        private readonly IRidehistoriesService _ridehistoriesService;

        public RideHistoryController()
        {
            _ridehistoriesService = new RidehistoriesService();
        }

        // GET api/user/id
        public HttpResponseMessage Get(string id)
        {

            var ridehistory = _ridehistoriesService.Get(id);
            if (ridehistory.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, ridehistory);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, " ridehistory not found for provided username");
        }


        public HttpResponseMessage GetAll()
        {
            var rideHistories = _ridehistoriesService.GetAll();

            if (rideHistories.Any())
                return Request.CreateResponse(HttpStatusCode.OK, rideHistories);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No result found.");
            /*
            if (rideHistories != null)
            {
                var rideHistoryEntities = rideHistories as List<RideHistoriesEntity> ?? rideHistories.ToList();
                if (rideHistoryEntities.any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, rideHistoryEntities);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Users found.");
                */
            }

        [Route("RidesCount")]
        public HttpResponseMessage GetRidesCount()
        {
            RidesCount ridesCount = _ridehistoriesService.GetRidesCount();
            List<RidesCount> list = new List<RidesCount>();
            list.Add(ridesCount);
            return Request.CreateResponse(HttpStatusCode.OK, list);

        }

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

        [Route("RidesByLocation")]
        public HttpResponseMessage GetAllByLocation()
        {
            var rideHistories = _ridehistoriesService.GetRidesByLocation().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, rideHistories);

        }

        [Route("NoOfRidesByDrivers")]
        public HttpResponseMessage GetRideCountByDrivers()
        {           
            var rideHistories = _ridehistoriesService.GetRideCountByDrivers().ToList();            
            return Request.CreateResponse(HttpStatusCode.OK, rideHistories);

        }

        [Route("DistanceByMonth")]
        public HttpResponseMessage GetDistanceByMonth()
        {
            var rideHistories = _ridehistoriesService.GetDistanceByMonth().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, rideHistories);

        }

    }
}

