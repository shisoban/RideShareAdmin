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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        
        private readonly ICoordinateService _usercoordinateService;

        public UserController(ICoordinateService coordinate)
        {
           
            _usercoordinateService = coordinate;
        }

        // GET api/User/CountUser
        [Route("CountUser")]
        public HttpResponseMessage GetCountuser()
        {
            UserCalculations userCount = _usercoordinateService.GetUserCount();
            List<UserCalculations> list = new List<UserCalculations>();
            list.Add(userCount);
            return Request.CreateResponse(HttpStatusCode.OK, list);

        }

        // GET api/User/CountUser
        public HttpResponseMessage GetAllCoordinates()
        {
            var usercoordinates = _usercoordinateService.GetAllCoordinate();
            if (usercoordinates.Any())
                return Request.CreateResponse(HttpStatusCode.OK, usercoordinates);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No result found.");
        }
    }
}
