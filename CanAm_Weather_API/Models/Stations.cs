using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanAm_Weather_API.Models
{
    public class Stations
    {
        [JsonProperty("@context")]
        public List<object> context { get; set; }
        public string type { get; set; }
        public List<Feature> features { get; set; }
        public List<string> observationStations { get; set; }
        public Pagination pagination { get; set; }
    }

    public class Elevation
    {
        public string unitCode { get; set; }
        public double value { get; set; }
    }

    public class Feature
    {
        public string id { get; set; }
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Pagination
    {
        public string next { get; set; }
    }

    public class Properties
    {
        [JsonProperty("@id")]
        public string id { get; set; }

        [JsonProperty("@type")]
        public string type { get; set; }
        public Elevation elevation { get; set; }
        public string stationIdentifier { get; set; }
        public string name { get; set; }
        public string timeZone { get; set; }
        public string forecast { get; set; }
        public string county { get; set; }
        public string fireWeatherZone { get; set; }
    }
}
