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
            }
                return View();
        }

        public JsonResult StateList(string id)
        {
            using (EventDBEntities db= new EventDBEntities())
            {    
                var State = new SelectList(db.States.ToList(), "StateID", "StateName");
                return Json(State, JsonRequestBehavior.AllowGet);
            }
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