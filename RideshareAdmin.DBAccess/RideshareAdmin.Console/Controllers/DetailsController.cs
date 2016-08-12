using RideshareAdmin.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RideshareAdmin.Console.ServiceWrapp;

namespace RideshareAdmin.Console.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult UserList()
        {
            ServiceWrapper sw = new ServiceWrapper();
            //var usermodel = sw.GetUsers();
            //ViewBag.Message = "90";
            UserDetailViewModel vm = new UserDetailViewModel();
            vm.Users = sw.GetUsers();
            // vm.Noofkillometer = "234";
            // return View(vm);
            return View(vm);
        }


        [Authorize]
        public ActionResult Rides(RideListViewModel ridelistvme)
        {
            ServiceWrapper sw = new ServiceWrapper();
            //var usermodel = sw.GetUsers();
            //ViewBag.Message = "90";
            RideListViewModel vm = new RideListViewModel();
            //var p = sw.GetRidesDatarange();
            string startdate = Convert.ToDateTime(System.DateTime.Today.AddDays(-30)).ToString("yyyy-MM-dd");
            string enddate = Convert.ToDateTime(System.DateTime.Today).ToString("yyyy-MM-dd"); 
            vm.RideList = sw.GetRidesDatarange(startdate, enddate);
            // vm.Noofkillometer = "234";
            // return View(vm);
            return View(vm);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Rides(RideListViewModel ridelistvm, string startdate, string endate)
        {
            ServiceWrapper sw = new ServiceWrapper();
            //var usermodel = sw.GetUsers();
            //ViewBag.Message = "90";
            RideListViewModel vm = new RideListViewModel();
            //var p = sw.GetRidesDatarange();
            
            string strUtcTime_startdate = Convert.ToDateTime(startdate).ToString("yyyy-MM-dd");
            string strUtcTime_enddate   = Convert.ToDateTime(endate).ToString("yyyy-MM-dd");
            vm.RideList = sw.GetRidesDatarange(startdate, endate);
            // vm.Noofkillometer = "234";
            // return View(vm);
            return View(vm);
        }
        public ActionResult test(RideListViewModel ridelistvme)
        {
            ServiceWrapper sw = new ServiceWrapper();
            //var usermodel = sw.GetUsers();
            //ViewBag.Message = "90";
            RideListViewModel vm = new RideListViewModel();
            //var p = sw.GetRidesDatarange();
            vm.RideList = sw.GetRides();
            // vm.Noofkillometer = "234";
            // return View(vm);
            return View(vm);
        }
    }
}