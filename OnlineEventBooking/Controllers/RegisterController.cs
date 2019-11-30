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
                var country = db.Countries.ToList();
                List<SelectListItem> dd = new List<SelectListItem>();
                dd = country;
                ViewBag.countrylist = dd;
            }
                return View();
        }

        public JsonResult StateList(int id)
        {
            using (EventDBEntities db= new EventDBEntities())
            {
                var State = db.States.Where(x => x.CountryID == id).ToList();
                return Json(State, JsonRequestBehavior.AllowGet);
            }
        }
    }
}