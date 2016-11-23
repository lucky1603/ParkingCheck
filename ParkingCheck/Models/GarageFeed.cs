using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;

namespace ParkingCheck.Models
{   
    public class GarageFeed
    {
        private List<Garage> garages = new List<Garage>();
        private Uri connectonUri;

        private void GetGarages()
        {
            Timer t = new Timer(tick,null, 1000, 1000);
        }

        private void tick(object state)
        {
            RefreshGarages();
        }

        private void RefreshGarages()
        {
            WebClient client = new WebClient();
            
        }
    }
}