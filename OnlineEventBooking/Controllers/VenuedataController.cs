using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using OnlineEventBooking.ViewModel;
using System.IO;

namespace OnlineEventBooking.Controllers
{
    public class VenuedataController : Controller
    {
        // GET: Venuedata
        [HttpGet]
        public ActionResult SaveVenue()
        {
            return View("Venue");
        }
        [HttpPost]
        public ActionResult SaveVenue(VenueViewModel vvm)
        {

            if (ModelState.IsValid)
            {


                Venue v = new Venue();
                v.VenueCost = vvm.VenueCost;
                v.VenueFilename = Path.GetFileNameWithoutExtension(vvm.imageFile.FileName);
                v.VenueName = vvm.VenueName;
                using (EventDBEntities db = new EventDBEntities())
                {
                    
                    db.Venues.Add(v);
                    db.SaveChanges();
                }
            }

            return View("Venue");
        }

        public ActionResult List()
        {
            using (EventDBEntities db= new EventDBEntities())
            {
                var vanues = (from x in db.Venues select x).ToList();
                return View(vanues);
            }
               
        }


        public ActionResult Edit(int  Id)
        {
            using (EventDBEntities db = new EventDBEntities())
            {
                var vanues = (from x in db.Venues where x.VenueID == Id select x new VenueViewModel() { } );
                return View("Venue", vanues);
            }

           
        }
    }
}