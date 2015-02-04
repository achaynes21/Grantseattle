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
    public class MapLocationModel
    {
        public string LookupAddress
        {
            get;
            set;
        }
        public string ActualAddress
        {
            get;
            set;
        }
        public string Lat
        {
            get;
            set;
        }
        public string Lng
        {
            get;
            set;
        }
        public int Zoom
        {
            get;
            set;
        }
    }
    public class GoogleMapsApiHelper
    {
       
        public static MapLocationModel Geocode(string address)
        {
            string[] addressParts = address.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            string address_CSC = String.Join(",", addressParts.Reverse().Take(3).Reverse());

            int count = 0,
                zoomLevel = 14,
                maxRequests = App.Configurations.MaximumGeocodingRequest.Value;

            MapLocationModel location = null;

            while (count < maxRequests && location == null)
            {
                location = _geocode(String.Join(",", addressParts), false);
                addressParts = addressParts.Skip(1).ToArray<string>();
                zoomLevel -= 2;

                count++;
            }

            if (location == null)
            {
                addressParts = address_CSC.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                zoomLevel = 10;

                while (location == null)
                {
                    location = _geocode(String.Join(",", addressParts), false);
                    addressParts = addressParts.Skip(1).ToArray<string>();
                    zoomLevel -= 2;

                    count++;
                }
            }

            location.Zoom = zoomLevel;

            return location;
        }

        private static MapLocationModel _geocode(string address, bool sensor)
        {
            WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&sensor=" + sensor.ToString().ToLower());
            request.Method = "GET";
            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string json = reader.ReadToEnd();

            JObject obj = JObject.Parse(json);

            if (obj["status"].ToString().ToLower() == "ok")
            {
                MapLocationModel location = JsonConvert.DeserializeObject<MapLocationModel>(obj["results"][0]["geometry"]["location"].ToString());
                location.ActualAddress = obj["results"][0]["formatted_address"].ToString();
                location.LookupAddress = address;

                return location;
            }
            else
            {
                return null;
            }
        }
    }
}
