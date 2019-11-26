using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using OnlineEventBooking.Models;
using OnlineEventBooking.ViewModel;
namespace OnlineEventBooking.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Create()
        {
            List<SelectListItem> DishList = new List<SelectListItem>() {
                new SelectListItem { Text = "Delux", Value = "1" },
                new SelectListItem { Text ="Regular",Value ="2"}
            };
            ViewBag.DishList = DishList;
            return View("Add");
        }

        public ActionResult save(Food Foo)
        {
            if (Request.Files.Count > 0)
            {
                Foo.ImageFile.SaveAs(Server.MapPath("~/UploadImage/" + Foo.ImageFile.FileName.ToString()));
                Foo.FoodFilePath = Foo.ImageFile.FileName.ToString();
                Foo.FoodFilename = Foo.ImageFile.FileName.ToString();
            }
            using (EventDBEntities db = new EventDBEntities())
            {


                db.Foods.Add(Foo);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            using (EventDBEntities db = new EventDBEntities())
            {
                var Dishtypelist = Enum.GetValues(typeof(DishtypeList)).Cast<DishtypeList>()
              .Select(r => new { Value = (int)r, Name = r.ToString() }).ToList();


                var MealtypeList = Enum.GetValues(typeof(MealtypeList)).Cast<MealtypeList>()
             .Select(r => new { Value = (int)r, Name = r.ToString() }).ToList();

                var FoodtypeList = Enum.GetValues(typeof(FoodtypeList)).Cast<FoodtypeList>()
             .Select(r => new { Value = (int)r, Name = r.ToString() }).ToList();



                var Foodlist = (from x in db.Foods select x).ToList();

                var result1 = from t in Foodlist
                              join x in Dishtypelist on t.DishType equals x.Value
                              join y in FoodtypeList on Convert.ToInt32(t.FoodType) equals y.Value
                              join z in MealtypeList on Convert.ToInt32(t.MealType) equals z.Value
                              select new FoodViewModel { FoodID = t.FoodID, FoodName = t.FoodName, DishType = x.Name, FoodType = y.Name, MealType = z.Name, FoodFilePath = t.FoodFilePath, FoodFilename = t.FoodFilePath, FoodCost = t.FoodCost };






                return View("List", result1.ToList());


                //One other Way
                //Dictionary<int, string> DicRoles = new Dictionary<int, string>();
                //var vals = Enum.GetValues(typeof(Dishtype));

                //foreach (var val in vals)
                //{
                //    DicRoles.Add((int)val, val.ToString());
                //}

                //var result = from t in Foodlist
                //             join x in DicRoles on t.DishType equals x.Key
                //             select new { t.FoodName , dishtype=x.Value   };


            }










        }

        public ActionResult Edit(int id)
        {
            using (EventDBEntities db = new EventDBEntities())
            {
                List<SelectListItem> DishList = new List<SelectListItem>() {
                new SelectListItem { Text = "Delux", Value = "1" },
                new SelectListItem { Text ="Regular",Value ="2"}
            };
                ViewBag.DishList = DishList;
                var foo = (from x in db.Foods where x.FoodID == id select x).FirstOrDefault();
                
                return View(foo);

            }



        }

        public ActionResult Update(Food Foo)
        {
            using (EventDBEntities db = new EventDBEntities())
            {
                if (Foo.ImageFile.FileName!="")
                {
                    Foo.ImageFile.SaveAs(Server.MapPath("~/UploadImage/" + Foo.ImageFile.FileName.ToString()));
                    Foo.FoodFilePath = Foo.ImageFile.FileName.ToString();
                    Foo.FoodFilename = Foo.ImageFile.FileName.ToString();
                    db.Entry(Foo).State = System.Data.Entity.EntityState.Modified;
                   
                }
                else
                {
                    db.Foods.Attach(Foo);
                    db.Entry(Foo).Property(x => x.FoodName).IsModified = true;
                    db.Entry(Foo).Property(x => x.DishType).IsModified = true;
                    db.Entry(Foo).Property(x => x.MealType).IsModified = true;
                    db.Entry(Foo).Property(x => x.FoodType).IsModified = true;
                    db.Entry(Foo).Property(x => x.FoodCost).IsModified = true;
                  
                }
                db.SaveChanges();

            }
            return View();
        }
    }
}