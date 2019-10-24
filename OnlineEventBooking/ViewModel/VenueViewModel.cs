using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineEventBooking.ViewModel
{
    public class VenueViewModel
    {
        public string VenueName { get; set; }
        public string VenueFilename { get; set; }        
        public Nullable<int> VenueCost { get; set; }

        public HttpPostedFileBase imageFile { get; set; }
    }
}