using Newtonsoft.Json;

namespace CanAm_Weather_API_Page.Models
{
    public class HourlyForecast
    {
        [JsonProperty("@context")]
        public List<object> context { get; set; }
        public string type { get; set; }
        [JsonProperty("Geometry")]
        public HourlyGeometry geometry { get; set; }
        [JsonProperty("Properties")]
        public HourlyProperties properties { get; set; }
    }

    public class HourlyDewpoint
    {
        public string unitCode { get; set; }
        public double value { get; set; }
    }

    public class HourlyElevation
    {
        public string unitCode { get; set; }
        public double value { get; set; }
    }

    public class HourlyGeometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class HourlyPeriod
    {
        public int number { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool isDaytime { get; set; }
        public int temperature { get; set; }
        public string temperatureUnit { get; set; }
        public object temperatureTrend { get; set; }
        [JsonProperty("ProbabilityOfPrecipitation")]
        public HourlyProbabilityOfPrecipitation probabilityOfPrecipitation { get; set; }
        [JsonProperty("Dewpoint")]
        public HourlyDewpoint dewpoint { get; set; }
        [JsonProperty("RelativeHumidity")]
        public HourlyRelativeHumidity relativeHumidity { get; set; }
        public string windSpeed { get; set; }
        public string windDirection { get; set; }
        public string icon { get; set; }
        public string shortForecast { get; set; }
        public string detailedForecast { get; set; }
    }

    public class HourlyProbabilityOfPrecipitation
    {
        public string unitCode { get; set; }
        public int value { get; set; }
    }

    public class HourlyProperties
    {
        public DateTime updated { get; set; }
        public string units { get; set; }
        public string forecastGenerator { get; set; }
        public DateTime generatedAt { get; set; }
        public DateTime updateTime { get; set; }
        public string validTimes { get; set; }
        [JsonProperty("Elevation")]
        public HourlyElevation elevation { get; set; }
        public List<HourlyPeriod> periods { get; set; }
    }

    public class HourlyRelativeHumidity
    {
        public string unitCode { get; set; }
        public int value { get; set; }
    }
}
