using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Core.Helper
{
    public class LocationLookupHelper
    {
        public class LocationLookupModel
        {
            public string IP
            {
                get;
                set;
            }
            public string CountryCode
            {
                get;
                set;
            }
            public string CountryName
            {
                get;
                set;
            }

            public string City
            {
                get;
                set;
            }

            public string Latitude
            {
                get;
                set;
            }
            public string Longitude
            {
                get;
                set;
            }

        }
        public static LocationLookupModel GetLocation(string ipaddress)
        {
            WebRequest request = WebRequest.Create("http://freegeoip.net/json/"+ipaddress);
            request.Method = "GET";
            request.ContentType = "application/json";
            
            try
            {
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string json = reader.ReadToEnd();
                JObject obj = JObject.Parse(json);

                var location = new LocationLookupModel
                {
                    IP = (string)obj["ip"],
                    City = (string)obj["city"],
                    CountryCode = (string)obj["country_code"],
                    CountryName = (string)obj["country_name"],
                    Latitude = (string)obj["latitude"],
                    Longitude = (string)obj["longitude"],

                };

                return location;
            }
            catch
            {
                return new LocationLookupModel();
            }
        }


    }
}
