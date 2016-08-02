using RideshareAdmin.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RideshareAdmin.Console.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            //ViewBag.Message = "90";
            DashboardVIewModel vm = new DashboardVIewModel();
            vm.Noofkillometer = "234";
            return View(vm);
           
        }
    }
}