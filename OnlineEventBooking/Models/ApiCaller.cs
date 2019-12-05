using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using DAL;
namespace OnlineEventBooking.Models
{
    public class ApiCaller
    {
        public HttpClient ApiBaseaddress()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress= new Uri("https://localhost:44372/");
                return client;
            }
        }

        public string VenueApi(BookingVenue bv)
        {
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/");
                var postTask = client.PostAsJsonAsync<BookingVenue>("VenueApi", bv);
                postTask.Wait();

                var result = postTask.Result;

                return result.RequestMessage.ToString(); ;
            }
            
        }
    }



}