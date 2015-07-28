using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HN.eCommerce.WebUI.Core;
using System.ComponentModel.Composition;

namespace HN.eCommerce.WebUI.Controllers.MVC
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Authorize]
    public class CustomerController : ViewControllerBase
    {

        [HttpGet]
        public ActionResult ReserveCar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReserveProduct()
        {
            return View();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}