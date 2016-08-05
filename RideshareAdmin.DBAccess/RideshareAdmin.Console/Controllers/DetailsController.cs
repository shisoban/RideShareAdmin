﻿using RideshareAdmin.Console.Models;
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

        public ActionResult UserList()
        {
            ServiceWrapper sw = new ServiceWrapper();
            UserModel usermodel = sw.GetUsers();
            //ViewBag.Message = "90";
            UserDetailViewModel vm = new UserDetailViewModel();
            vm.userName = usermodel.firstname;
            vm.lastname = usermodel.lastname;
            vm.firstname = usermodel.lastname;
            vm.email = usermodel.email;
            
            
            
           // vm.Noofkillometer = "234";
           // return View(vm);
            return View(vm);
        }
    }
}