using Newtonsoft.Json;

namespace CanAm_Weather_API_Page.Models
{
    public class Forecast
    {
        [JsonProperty("@context")]
        public List<object> context { get; set; }
        public string type { get; set; }
        [JsonProperty("Geometry")]
        public ForecastGeometry forecastGeometry { get; set; }
        [JsonProperty("Properties")]
        public ForecastProperties forecastProperties { get; set; }
    }

    public class Dewpoint
    {
        public string unitCode { get; set; }
        public double value { get; set; }
    }

    public class ForecastElevation
    {
        public string unitCode { get; set; }
        public double value { get; set; }
    }

    public class ForecastGeometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class Period
    {
        public int number { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool isDaytime { get; set; }
        public int temperature { get; set; }
        public string temperatureUnit { get; set; }
        public object temperatureTrend { get; set; }
        public ProbabilityOfPrecipitation probabilityOfPrecipitation { get; set; }
        public Dewpoint dewpoint { get; set; }
        public RelativeHumidity relativeHumidity { get; set; }
        public string windSpeed { get; set; }
        public string windDirection { get; set; }
        public string icon { get; set; }
        public string shortForecast { get; set; }
        public string detailedForecast { get; set; }
    }

    public class ProbabilityOfPrecipitation
    {
        public string unitCode { get; set; }
        public int? value { get; set; }
    }

    public class ForecastProperties
    {
        public DateTime updated { get; set; }
        public string units { get; set; }
        public string forecastGenerator { get; set; }
        public DateTime generatedAt { get; set; }
        public DateTime updateTime { get; set; }
        public string validTimes { get; set; }
        [JsonProperty("Elevation")]
        public ForecastElevation forecastElevation { get; set; }
        public List<Period> periods { get; set; }
    }

    public class RelativeHumidity
    {
        public string unitCode { get; set; }
        public int value { get; set; }
    }

    public class Root
    {
        
    }
}
