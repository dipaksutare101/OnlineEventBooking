using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using OnlineEventBooking.Models;
namespace OnlineEventBooking.Controllers
{
    public class BookingVenueController : Controller
    {
        
        public ActionResult Add()
        {
            using (EventDBEntities db=new EventDBEntities())
            {
                var VenueList = new SelectList((from x in db.Venues select new { x.VenueID, x.VenueName }).ToList(), "VenueID", "VenueName");
                ViewBag.Venuelist = VenueList;

                var EventList = new SelectList((from x in db.Events select new { x.EventID, x.EventType }).ToList(), "EventID", "EventType");
                ViewBag.EventList = EventList;
            }
                return View();
        }
        [HttpPost]
        public ActionResult Add(BookingVenue bv)
        {
            ApiCaller ac = new ApiCaller();
            ac.VenueApi(bv);
            return RedirectToAction("Add","BookingEquipment");
        }
    }
}