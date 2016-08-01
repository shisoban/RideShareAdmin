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
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        // GET api/user/id
        public HttpResponseMessage Get(int id)
        {

            var user = _userService.Get(id);
            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found for provided id.");
        }

        public HttpResponseMessage GetAll()
        {
            var user = _userService.GetAll();
            if (user.Any())
                return Request.CreateResponse(HttpStatusCode.OK, user);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Users found.");
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
