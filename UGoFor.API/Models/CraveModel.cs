using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGoFor.API.DAL;

namespace UGoFor.API.Models
{
    public class CraveModel
    {
        public int UserId { get; set; }
        public int Type { get; set; }
        public int? PostId { get; set; }
        public string CravingTextShort { get; set; }
        public string CravingTextLong { get; set; }
        public string CravingPic { get; set; }
        public string TimePosted { get; set; }
        public string Location { get; set; }

        public void InsertCrave(CraveModel crave)
        {
            crave.CravingTextLong = GetGeoLocation(crave.Location);
            new CraveDAL().InsertCrave(crave);
        }

        public string GetGeoLocation(string coords)
        {
            string retval = string.Empty;

            if (coords.Trim().Equals("NULL"))
            {
                return retval;
            }

            try
            {
                coords = coords.Replace("Latitude: ", "").Replace(" Longitude: ", ",");
                var address = "http://maps.google.com/maps/api/geocode/json?address={0}&sensor=false";
                var result = new System.Net.WebClient().DownloadString(string.Format(address, coords));
                GoogleGeoCodeResponse test = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(result);
                var res = test.results.Where(x => (!x.types.Contains("street_address")) && (!x.types.Contains("postal_code"))).First();
                //foreach (var fa in test.results.Where(x => (!x.types.Contains("street_address")) && (!x.types.Contains("postal_code"))))
                //{
                //    Console.WriteLine(fa.formatted_address);
                //}
                retval = res.formatted_address;
            }
            catch { }
            return retval;
        }
    }

    #region Google Helper Class
    public class GoogleGeoCodeResponse
    {
        public string status { get; set; }
        public results[] results { get; set; }
    }

    public class results
    {
        public string formatted_address { get; set; }
        public geometry geometry { get; set; }
        public string[] types { get; set; }
        public address_component[] address_components { get; set; }
    }

    public class geometry
    {
        public string location_type { get; set; }
        public location location { get; set; }
    }

    public class location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class address_component
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }
    #endregion
}