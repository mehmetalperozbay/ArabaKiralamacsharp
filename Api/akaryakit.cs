using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace ConsoleApp8.Api
{
    public class akaryakit
    {

        public static void opetyakit()
        {
            string url = "https://api.opet.com.tr/api/fuelprices/prices?ProvinceCode=35&IncludeAllProducts=true";
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;

                    string newresponse = response.Content.ReadAsStringAsync().Result;

                    JObject responsejson = JObject.Parse(newresponse);

                    string districtName = "BAYRAKLI";

                    var fuelprices = responsejson[districtName];
                }
                catch (Exception ex) { 
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
