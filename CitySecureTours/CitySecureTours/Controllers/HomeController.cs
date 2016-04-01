using CityToursMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CityToursMVC.Controllers
{
    public class HomeController : Controller
    {   
        //[Authorize]
        public ActionResult Index()
        {

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminIndex()
        {
            return View();
        }
    }
}