using ParkingCheck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkingCheck.Controllers
{
    public class GaragesController : ApiController
    {
        private Repository garages;

        public GaragesController() : base()
        {
            garages = Repository.Current;
            //GarageDataCollector collector = new GarageDataCollector(garages);
        }

        // GET: api/Garages
        public IEnumerable<Garage> Get()
        {
            return garages.GetAll();
        }

        // GET: api/Garages/5
        public Garage Get(int id)
        {
            return garages.Get(id);
        }

        // POST: api/Garages
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Garages/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Garages/5
        public void Delete(int id)
        {
        }
    }
}
