using RideshareAdmin.Console.Models;
using RideshareAdmin.Console.ServiceWrapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RideshareAdmin.Console.Controllers
{
    public class DashboardController : Controller
    {
        private ServiceWrapper sw = new ServiceWrapper();
        
        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {
            DashboardStatics chartdata = sw.GetNumberstatics();
        //ViewBag.Message = "90";
            DashboardVIewModel vm = new DashboardVIewModel();
            vm.Noofkillometer = "234";
            vm.Noofusers = chartdata.noofusers;
            return View(vm);
           
        }
    }
}