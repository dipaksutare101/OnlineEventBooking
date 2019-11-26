using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEventBooking.ViewModel
{
    public class FoodViewModel
    {
            public int FoodID { get; set; }
            public string FoodType { get; set; }
            public string MealType { get; set; }
            public string DishType { get; set; }
            public string FoodName { get; set; }
            public string FoodFilename { get; set; }
            public string FoodFilePath { get; set; }
            public Nullable<int> FoodCost { get; set; }
        
    }
}