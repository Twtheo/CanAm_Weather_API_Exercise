using CanAm_Weather_API_Page.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CanAm_Weather_API_Page.Controllers
{
    [ApiController]
    [Route("api/[controller]/GetForecast")]
    public class GetForecastController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public GetForecastController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public async Task<string> GetForecast()
        {
            var forecastRequest = new HttpRequestMessage(HttpMethod.Get, $"https://api.weather.gov/gridpoints/TOP/32,81/forecast");
            var hourlyRequest = new HttpRequestMessage(HttpMethod.Get, $"https://api.weather.gov/gridpoints/TOP/32,81/forecast/hourly");


            var appValue = new ProductInfoHeaderValue("CanAm_Weather_Exercise", "1.0");
            var emailValue = new ProductInfoHeaderValue("(+CanAmWeatherExercise@gmail.com)");

            forecastRequest.Headers.UserAgent.Add(appValue);
            forecastRequest.Headers.UserAgent.Add(emailValue);

            hourlyRequest.Headers.UserAgent.Add(appValue);
            hourlyRequest.Headers.UserAgent.Add(emailValue);

            var forecastResponse = await _httpClient.SendAsync(forecastRequest);
            var hourlyResponse = await _httpClient.SendAsync(hourlyRequest);

            var forecastInfo = JsonConvert.DeserializeObject<Forecast>(forecastResponse.Content.ReadAsStringAsync().Result);
            var hourlyInfo = JsonConvert.DeserializeObject<HourlyForecast>(hourlyResponse.Content.ReadAsStringAsync().Result);

            string forecastString = "";

            forecastString += "| WEEKLY FORECAST\n";
            foreach (var period in forecastInfo.forecastProperties.periods)
            {
                forecastString += $"| {period.name}" +
                                  $"\n| Temperature: {period.temperature} F" +
                                  $"\n| Forecast: {period.detailedForecast}" +
                                  $"\n---------------------------------------------------------------------------------------------------------\n";
            }

            
            forecastString += "\n---------------------------------------------------------------------------------------------------------";
            forecastString += "\n| HOURLY FORECAST\n";
            foreach (var period in hourlyInfo.properties.periods)
            {
                forecastString += $"| Hourly: {period.startTime.ToString("yyyy-M-dd hh tt")} - {period.endTime.ToString("hh tt")}" +
                                  $"\n| Temperature: {period.temperature} F" +
                                  $"\n| Forecast: {period.shortForecast}" +
                                  $"\n---------------------------------------------------------------------------------------------------------\n";
            }


            return forecastString;
        }
    }
}
