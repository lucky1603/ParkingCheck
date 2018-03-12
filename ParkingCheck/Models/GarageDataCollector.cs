using HtmlAgilityPack;
using System;

namespace ParkingCheck.Models
{
    public class GarageDataCollector
    {
        private string address = "http://parking-servis.co.rs/lat/gde-mogu-da-parkiram/";

        public GarageDataCollector(Repository repo, string address = null)
        { 
            if(address != null)
            {
                this.address = address;
            }        
                
            this.SyncData(repo);
        }
        
        private void SyncData(Repository repo)
        {
            HtmlWeb web = new HtmlWeb();            
            HtmlDocument doc = web.Load(this.address);
            
            foreach (HtmlNode tableRow in doc.DocumentNode.SelectNodes("//div[@class=\"table-1\"]/table/tbody/tr"))
            {
                // I varijanta
                //var fields = tableRow.ChildNodes.Where(id => id.Name == "td").ToArray();
                //string a = fields[0].InnerText;
                //string b = fields[1].InnerText;

                // II varijanta
                //HtmlNodeCollection tableFields = tableRow.SelectNodes(".//td");
                //string strGarageName = tableFields[0].InnerText;
                //strGarageName = strGarageName.Replace("„", "- ");
                //strGarageName = strGarageName.Replace("&#8221;", "");
                //strGarageName = strGarageName.Replace("&#8220;", "");

                //string d = tableFields[1].InnerText;
                //int placesFree = Int32.Parse(d);


                // III Varijanta
                HtmlNodeCollection garageNodes = tableRow.SelectNodes(".//td");
                foreach(HtmlNode garageNode in garageNodes)
                {
                    HtmlNode garageNameNode = garageNode.SelectSingleNode(".//h5");
                    if (garageNameNode == null)
                        continue;

                    String garageName = garageNameNode.InnerText;

                    HtmlNode garageFreePlacesNode = garageNode.SelectSingleNode(".//h2");
                    String freePlaces = garageFreePlacesNode.InnerText;

                    Garage garage = repo.GetByName(garageName);
                    if (garage != null)
                    {
                        garage.PlacesFree = Int32.Parse(freePlaces);
                    }

                }

                               
            }
        }
    }
}