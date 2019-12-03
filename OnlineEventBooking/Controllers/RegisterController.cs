using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
namespace OnlineEventBooking.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            using (EventDBEntities db= new EventDBEntities())
            {
                var country = new SelectList(db.Countries.ToList(), "CountryID","Name");
               
                ViewBag.countrylist = country;
            }
                return View();
        }

        public JsonResult StateList()
        {
            using (EventDBEntities db= new EventDBEntities())
            {    
                var State = new SelectList(db.States.ToList(), "StateID", "StateName");
                return Json(State, JsonRequestBehavior.AllowGet);
            }
        }
    }
}