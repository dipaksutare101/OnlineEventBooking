using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
namespace OnlineEventBooking.Controllers
{
    public class EquipmentController : Controller
    {
        // GET: Equipment
        public ActionResult Create()
        {
            return View("AddEquipment");
        }
        public ActionResult Save(Equipment Equ)
        {
            if (Request.Files.Count > 0)
            {
                if(ModelState.IsValid)
                { 
                    String FName = Equ.ImageFile.FileName.ToString();
                    Equ.ImageFile.SaveAs(Server.MapPath("~/UploadImage/" + Equ.ImageFile.FileName.ToString()));

                    using(EventDBEntities db= new EventDBEntities())
                    {
                        Equ.EquipmentFilename = FName;
                        db.Equipments.Add(Equ);
                        db.SaveChanges();
                    }
                }

            }
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            using (EventDBEntities db= new EventDBEntities())
            {
                var Euipmentlist = (from x in db.Equipments select x).ToList();
                return View(Euipmentlist);
            }
        }

        public  ActionResult Edit(int id)
        {
            using (EventDBEntities db= new EventDBEntities())
            {
                var equdata = (from x in db.Equipments where x.EquipmentID == id select x).FirstOrDefault();
                equdata.EquipmentFilename = "~/UploadImage/" + equdata.EquipmentFilename;
                return View(equdata);
            }
              
        }

        public  ActionResult UpdateSave(Equipment euq)
        {
            using (EventDBEntities db= new EventDBEntities())
            {
                 
                    Equipment e = new Equipment();
                    e.EquipmentName = euq.EquipmentName;
                    e.EquipmentID = euq.EquipmentID;
                    e.EquipmentCost = euq.EquipmentCost;

                    if (euq.ImageFile==null)
                    {
                        
                        db.Equipments.Attach(e);
                        db.Entry(e).Property(x => x.EquipmentCost).IsModified = true;
                        db.Entry(e).Property(x => x.EquipmentName).IsModified = true;    
                    }
                    else
                    {
                        string FName = euq.ImageFile.FileName;
                        euq.ImageFile.SaveAs(Server.MapPath("~/UploadImage/" + FName));
                        e.EquipmentFilename = euq.ImageFile.FileName.ToString();
                        db.Entry(e).State = System.Data.Entity.EntityState.Modified;
                        
                    }
                    db.SaveChanges();

                    
                
                return RedirectToAction("List");
            }
        }

    }
}