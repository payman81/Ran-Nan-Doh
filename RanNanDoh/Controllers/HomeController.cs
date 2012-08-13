﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RanNanDoh.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Ran-Nan-Doh!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
