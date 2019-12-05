using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
namespace OnlineEventBooking.Controllers
{
    public class VenueApiController : ApiController
    {
        // GET: api/VenueApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/VenueApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/VenueApi
        public void Post(BookingVenue  bv)
        {
            using (EventDBEntities db= new EventDBEntities())
            {
                db.BookingVenues.Add(bv);
                db.SaveChanges();
            }
        }

        // PUT: api/VenueApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VenueApi/5
        public void Delete(int id)
        {
        }
    }
}
