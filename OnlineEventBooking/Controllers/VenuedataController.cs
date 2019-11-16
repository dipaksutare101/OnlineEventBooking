using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using OnlineEventBooking.ViewModel;
using System.IO;
using System.Data.Entity;

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

            if (ModelState.IsValid) //This is check all validation of Data Annotation
            {

                if (vvm.imageFile !=null)
                {
                    vvm.imageFile.SaveAs(Server.MapPath("~/UploadImage/" + vvm.imageFile.FileName));
                }

                Venue v = new Venue();
                v.VenueCost = vvm.VenueCost;
                v.VenueFilename = vvm.imageFile.FileName.ToString();
                v.VenueName = vvm.VenueName;
                using (EventDBEntities db = new EventDBEntities())
                {
                    
                    db.Venues.Add(v);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("List");
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
                var v = (from x in db.Venues where x.VenueID == Id select new { x.VenueCost, x.VenueFilename, x.VenueID, x.VenueName,x.VenueFilePath }).FirstOrDefault();

                VenueViewModel vvm = new VenueViewModel();
                vvm.VenueCost = v.VenueCost;
                vvm.VenueFilename = v.VenueFilename;
                vvm.VenueName = v.VenueName;
                vvm.VenueFilePath = "~/UploadImage/" + v.VenueFilePath;
                vvm.VenueID = v.VenueID;
             
                return View("Edit", vvm);
            }

           
        }


        public ActionResult UpdateData(VenueViewModel vvm)
        {


            using (EventDBEntities db= new EventDBEntities())
            {

                if (vvm.imageFile != null)
                {
                    vvm.imageFile.SaveAs(Server.MapPath("~/UploadImage/" + vvm.imageFile.FileName));
                }
                Venue v = new Venue();
                v.VenueCost = vvm.VenueCost;
               
                v.VenueID = vvm.VenueID ;
                v.VenueName = vvm.VenueName;
                if (vvm.imageFile!=null)
                {
                    v.VenueFilePath = vvm.imageFile.FileName.ToString();
                    v.VenueFilename = vvm.VenueFilename;
                    db.Entry(v).State = EntityState.Modified;
                }
                else
                {
                    db.Venues.Attach(v); // No Need to Add during Update ..this is only used when we want update specific propery
                    db.Entry(v).Property(x => x.VenueCost).IsModified = true; //this is only used when we want update specific propery
                    db.Entry(v).Property(x => x.VenueName).IsModified = true;
                }
               //db.Venues.Attach(v);// No Need to Add during Update 
                db.SaveChanges();


               return RedirectToAction("List");
                 
            }
             
        }
    }
}