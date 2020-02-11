using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using OnlineEventBooking.Models;
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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
           

            if (frm!=null)
            {
                using (EventDBEntities db = new EventDBEntities())
                {
                    string UserName1 = frm["Username"];
                    string Password = frm["Password"];

                    string Pwd = Encryptor.MD5Hash(Password).ToUpper();
                    var result = (from x in db.Registrations where x.Username == UserName1 && x.Password == Pwd select x).FirstOrDefault();
                   if(result!=null)
                    {
                        return RedirectToAction("List", "Venuedata");
                    }
                    

                }
            }
               return  View();
            
            

        }
    }
}