using HtmlAgilityPack;
using ParkingCheck.Overrides;
using System;
using System.Net;
using System.Text;

namespace ParkingCheck.Models
{
    public static class GarageDataCollector
    {
        public static bool WORKING = false;
                
        public static void SyncData(Repository repo, string address)
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            WORKING = true;
                                
            try
            {
                WebClient client = new MyWebClient();
                client.Encoding = Encoding.UTF8;
                var data = client.DownloadString(address);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(data);
            
                foreach (HtmlNode tableRow in doc.DocumentNode.SelectNodes("//div[@class=\"table-1\"]/table/tbody/tr"))
                {
                    // III Varijanta
                    HtmlNodeCollection garageNodes = tableRow.SelectNodes(".//td");
                    foreach(HtmlNode garageNode in garageNodes)
                    {
                        HtmlNode garageNameNode = garageNode.SelectSingleNode(".//h5");
                        if (garageNameNode == null)
                            continue;

                        String garageName = garageNameNode.InnerText.Trim(); 
                                                                       
                        HtmlNode garageFreePlacesNode = garageNode.SelectSingleNode(".//h2");
                        String freePlaces = garageFreePlacesNode.InnerText;

                        Garage garage = repo.GetByName(garageName);
                        if (garage != null)
                        {
                            garage.PlacesFree = Int32.Parse(freePlaces);
                        }
                    }                               
                }

            } catch (Exception ex)
            {
                string msg = ex.Message;
            }

            WORKING = false;
        }
    }
}