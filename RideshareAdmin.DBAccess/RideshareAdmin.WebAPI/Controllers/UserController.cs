using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RideshareAdmin.DBAccess.Models;
using RideshareAdmin.Services;
namespace RideshareAdmin.WebAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        // GET api/user/id
        public HttpResponseMessage Get(string id)
        {

            var user = _userService.Get(id);
            if (user.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found for provided username");
        }

        public HttpResponseMessage GetAll()
        {
            var user = _userService.GetAll();
            if (user.Any())
                return Request.CreateResponse(HttpStatusCode.OK, user);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Users found.");
        }

        [Route("Countuser")]
        public HttpResponseMessage GetCountuser()
        {
            var userCount = _userService.GetAll().Count();

            return Request.CreateResponse(HttpStatusCode.OK, userCount);

        }


        //public void Post([FromBody]User user)
        //{
        //    _userService.Insert(user);

        //}
        //public void Delete(int id)
        //{
        //    _userService.Delete(id);
        //}
        //public void Put([FromBody]User user)
        //{
        //    _userService.Update(user);
        //}
    }
}
