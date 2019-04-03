using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ParkingCheck.Overrides
{
    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
            return request;
        }
    }
}