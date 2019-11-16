using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEventBooking.Controllers
{
    public class EquipmentController : Controller
    {
        // GET: Equipment
        public ActionResult Create()
        {
            return View("AddEquipment");
        }
    }
}