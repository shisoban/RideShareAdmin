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

        // GET api/student/id
        public HttpResponseMessage Get(int id)
        {

            var student = _userService.Get(id);
            if (student != null)
            {
                // var i = student.StudentID + 2;
                return Request.CreateResponse(HttpStatusCode.OK, student);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found for provided id.");
        }

        public HttpResponseMessage GetAll()
        {
            var students = _userService.GetAll();
            if (students.Any())
                return Request.CreateResponse(HttpStatusCode.OK, students);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No students found.");
        }

        public void Post([FromBody]User student)
        {
            _userService.Insert(student);

        }
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
        public void Put([FromBody]User student)
        {
            _userService.Update(student);
        }
    }
}
