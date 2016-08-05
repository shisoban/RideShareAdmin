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
        private readonly IUserService _userService;
        private readonly ICoordinateService _usercoordinateService;

        public UserController()
        {
            _userService = new UserService();
            _usercoordinateService = new CoordinateService();
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

        //public HttpResponseMessage GetAll()
        //{
        //    var user = _userService.GetAll();
        //    if (user.Any())
        //        return Request.CreateResponse(HttpStatusCode.OK, user);
        //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Users found.");
        //}
        public HttpResponseMessage GetAll()
        {
            var users = _userService.GetAll();
            if (users != null)
            {
                var userEntities = users as List<UserEntity> ?? users.ToList();
                if (userEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, userEntities);
            }
            //return Request.CreateResponse(HttpStatusCode.OK, user);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Users found.");

            //var products = _productServices.GetAllProducts();
            //if (products != null)
            //{
            //    var productEntities = products as List<ProductEntity> ?? products.ToList();
            //    if (productEntities.Any())
            //        return Request.CreateResponse(HttpStatusCode.OK, productEntities);
            //}
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");

        }

        //[Route("Countuser")]
        //public HttpResponseMessage GetCountuser()
        //{
        //    var userCount = _userService.GetAll().Count();

        //    return Request.CreateResponse(HttpStatusCode.OK, userCount);

        //}

        [Route("CountUser")]
        public HttpResponseMessage GetCountuser()
        {
            UserCalculations userCount = _userService.GetUserCount();


            return Request.CreateResponse(HttpStatusCode.OK, userCount);

        }


        [Route("GetAllCoordinates")]
        public HttpResponseMessage GetAllCoordinates()
        {
            var usercoordinates = _usercoordinateService.GetAllCoordinate();
            if (usercoordinates.Any())
                return Request.CreateResponse(HttpStatusCode.OK, usercoordinates);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No result found.");
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
