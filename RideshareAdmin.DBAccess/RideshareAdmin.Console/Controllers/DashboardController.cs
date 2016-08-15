﻿using RideshareAdmin.Console.Models;
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
            DashboardVIewModel vm = new DashboardVIewModel();
            vm.Noofkillometer = "234";
            vm.Noofusers = chartdata.noofusers;
            vm.CountCurrentMonthRide = sw.GetCurrentMonthRideCount();
            vm.CurrentMonthCO2Reduction = sw.GetCurrentMonthCO2Reducation();
            vm.CO2Reductiontotal = sw.GetTotalCO2Reducation();
            vm.destinationName = sw.GetLocationVsRideCountdName();
            vm.countByDestination = sw.GetLocationVsRideCount_count();
            return View(vm);
           
        }
        public ActionResult TestCharts()
        {
            //DashboardStatics chartdata = sw.GetNumberstatics();
            //ViewBag.Message = "90";
            //   DashboardVIewModel vm = new DashboardVIewModel();
            // vm.Noofkillometer = "234";
            //  vm.Noofusers = chartdata.noofusers;
            return View();//(vm);

        }
    }
}