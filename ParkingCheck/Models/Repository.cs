using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ParkingCheck.Models
{
    public class Repository
    {
        private List<Garage> data;
        private static Repository repo;
        private Timer refreshTimer;

        static Repository()
        {
            repo = new Repository();
        }

        public static Repository Current
        {
            get
            {
                return repo;
            }
        }

        public Repository()
        {
            Garage[] garages = new Garage[]
            {
                new Garage {
                    Id = 1,
                    Name = "Garaža - Obilićev venac",
                    PlacesTotal = 619,
                    PlacesFree = 0,
                    Address = "Obilićev Venac",
                    Latitude = 44.815841,
                    Longitude = 20.4552323
                },
                new Garage {
                    Id = 2,
                    Name = "Garaža - Masarikova",
                    PlacesTotal = 460,
                    PlacesFree = 124, 
                    Address = "Masarikova 2",
                    Latitude = 44.807435,
                    Longitude = 20.463137
                },
                new Garage {
                    Id = 3,
                    Name = "Garaža - Zeleni venac",
                    PlacesTotal = 304,
                    PlacesFree = 0,
                    Address = "Kraljice Natalije 13",
                    Latitude = 44.812128,
                    Longitude = 20.45915
                },
                new Garage
                {
                    Id = 4,
                    Name = "Garaža - Pionirski park",
                    PlacesTotal = 472,
                    PlacesFree = 20,
                    Address = "Dragoslava Jovanovica 11",
                    Latitude = 44.811277,
                    Longitude = 20.463518
                },
                new Garage
                {
                    Id = 5,
                    Name = "Parkiralište - Sava centar",
                    PlacesTotal = 363,
                    PlacesFree = 74,
                    Address = "Milentija Popovica 9",
                    Latitude = 44.810242,
                    Longitude = 20.431451
                },
                new Garage
                {
                    Id = 6,
                    Name = "Parkiralište - Simpo",
                    PlacesTotal = 136,
                    PlacesFree = 19,
                    Address = "Hadži Nikole Živkovića",
                    Latitude = 44.812175,
                    Longitude = 20.452743
                },
                new Garage
                {
                    Id = 7,
                    Name = "Parkiralište - Aerodrom",
                    PlacesTotal = 569,
                    PlacesFree = 356,
                    Address = "Aerodrom Beograd",
                    Latitude = 44.818641,
                    Longitude = 20.288732
                },
                new Garage
                {
                    Id = 8,
                    Name = "Garaža - Vukov spomenik",
                    PlacesTotal = 121,
                    PlacesFree = 48,
                    Address = "Vukov Spomenik",
                    Latitude = 44.8047655,
                    Longitude = 20.4784268
                },
                new Garage
                {
                    Id = 9,
                    Name = "Parkiralište - Ada Ciganlija",
                    PlacesTotal = 1580,
                    PlacesFree = 1534,
                    Address = "Ada Ciganlija",
                    Latitude = 44.787069,
                    Longitude = 20.4130017
                },
                new Garage
                {
                    Id = 10,
                    Name = "Garaža - Dr A. Kostića",
                    PlacesTotal = 59,
                    PlacesFree = 53,
                    Address = "Dr Aleksandra Kostića ",
                    Latitude = 44.804707,
                    Longitude = 20.454867
                },
                new Garage
                {
                    Id = 11,
                    Name = "Parkiralište - Slavija",
                    PlacesTotal = 111,
                    PlacesFree = 0,
                    Address = "Trg Dimitrija Tucovića",
                    Latitude = 44.8045408,
                    Longitude = 20.4612794
                },
                new Garage
                {
                    Id = 12,
                    Name = "Parkiralište - Milan Gale Muškatirović",
                    PlacesTotal = 302,
                    PlacesFree = 267,
                    Address = "Tadeuša Košćuška",
                    Latitude = 44.828747,
                    Longitude = 20.4551426
                }
            };

            this.data = new List<Garage>();

            foreach(Garage g in garages)
            {
                data.Add(g);
            }

            this.refreshTimer = new Timer(refresh, null, 1000, 30000);
        }
        
        public IEnumerable<Garage> GetAll()
        {
            return data;
        }

        public Garage Get(int id)
        {
            return data.Where(g => g.Id == id).FirstOrDefault();
        }

        public Garage GetByName(string name)
        {
            return data.Where(g => g.Name == name).FirstOrDefault();
        }

        public void UpdatePlaces(int id, int places)
        {
            Garage garage = data.Where(g => g.Id == id).FirstOrDefault();
            if(garage != null)
            {
                garage.PlacesFree = places;
            }
        }

        private void refresh(object state)
        {
            new GarageDataCollector(this);
        }
    }
}