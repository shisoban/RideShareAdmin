using RideshareAdmin.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RideshareAdmin.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        /// <summary>
        /// The home page of the AdminLTE demo dashboard, recreated in this new system
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //ViewBag.Message = "90";
            DashboardVIewModel vm = new DashboardVIewModel();
            vm.Noofkillometer = "234";
            return View(vm);
        }

        /// <summary>
        /// The color page of the AdminLTE demo, demonstrating the AdminLte.Color enum and supporting methods
        /// </summary>
        /// <returns></returns>
        public ActionResult Colors()
        {
            return View();
        }
    }

}