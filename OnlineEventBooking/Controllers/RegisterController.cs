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

                var role = new SelectList(db.Roles.ToList(), "RoleID", "Rolename");

                ViewBag.Rolelist = role;
            }
                return View();
        }

        public JsonResult StateList(int id)
        {
            using (EventDBEntities db= new EventDBEntities())
            {    
                var State = new SelectList(db.States.Where(x=>x.CountryID ==id).ToList(), "StateID", "StateName");
                return Json(State, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult CityList(int id)
        {
            using (EventDBEntities db = new EventDBEntities())
            {
                var CityList = new SelectList(db.Cities.Where(x => x.StateID == id).ToList(), "CityID", "CityName");
                return Json(CityList, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Save(Registration reg)
        {
            using (EventDBEntities db= new EventDBEntities())
            {
                db.Registrations.Add(reg);
                db.SaveChanges();
            }
                return View("Register");
        }
    }
}