using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RideshareAdmin.DBAccess.Models;
using RideshareAdmin.Services;
using BusinessEntities;

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
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No students found.");
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


/*
          public HttpResponseMessage GetAll()
        {
            var students = _studentService.GetAll();
            if (students.Any())
                return Request.CreateResponse(HttpStatusCode.OK, students);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No students found.");
        }
        */

    }



}

