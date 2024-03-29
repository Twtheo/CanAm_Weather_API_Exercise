﻿using CanAm_Weather_API_Page.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CanAm_Weather_API_Page.Controllers
{
    [ApiController]  
    public class GetForecastController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ProductInfoHeaderValue _appValue = new ProductInfoHeaderValue("CanAm_Weather_Exercise", "1.0");
        private readonly ProductInfoHeaderValue _emailValue = new ProductInfoHeaderValue("(+CanAmWeatherExercise@gmail.com)");

        public GetForecastController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("api/[controller]/GetForecast")]
        public async Task<string> GetForecast()
        {
            var forecastRequest = new HttpRequestMessage(HttpMethod.Get, $"https://api.weather.gov/gridpoints/TOP/32,81/forecast");
            var hourlyRequest = new HttpRequestMessage(HttpMethod.Get, $"https://api.weather.gov/gridpoints/TOP/32,81/forecast/hourly");

            forecastRequest.Headers.UserAgent.Add(_appValue);
            forecastRequest.Headers.UserAgent.Add(_emailValue);

            hourlyRequest.Headers.UserAgent.Add(_appValue);
            hourlyRequest.Headers.UserAgent.Add(_emailValue);

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

        [HttpGet]
        [Route("api/[controller]/GetForecast/{x},{y}")]
        public async Task<string> GetForecast(double x, double y)
        {

            try
            {
                x = Math.Round(x, 4);
                y = Math.Round(y, 4);

                var pointsRequest = new HttpRequestMessage(HttpMethod.Get, $"https://api.weather.gov/points/{x},{y}");

                pointsRequest.Headers.UserAgent.Add(_appValue);
                pointsRequest.Headers.UserAgent.Add(_emailValue);

                var pointsResponse = await _httpClient.SendAsync(pointsRequest);

                var pointsInfo = JsonConvert.DeserializeObject<Points>(pointsResponse.Content.ReadAsStringAsync().Result);

                if (pointsInfo != null)
                {

                    var forecastRequest = new HttpRequestMessage(HttpMethod.Get, $"{pointsInfo.properties.forecast}");
                    var hourlyRequest = new HttpRequestMessage(HttpMethod.Get, $"{pointsInfo.properties.forecastHourly}");

                    forecastRequest.Headers.UserAgent.Add(_appValue);
                    forecastRequest.Headers.UserAgent.Add(_emailValue);

                    hourlyRequest.Headers.UserAgent.Add(_appValue);
                    hourlyRequest.Headers.UserAgent.Add(_emailValue);

                    var forecastResponse = await _httpClient.SendAsync(forecastRequest);
                    var hourlyResponse = await _httpClient.SendAsync(hourlyRequest);

                    var forecastInfo = JsonConvert.DeserializeObject<Forecast>(forecastResponse.Content.ReadAsStringAsync().Result);
                    var hourlyInfo = JsonConvert.DeserializeObject<HourlyForecast>(hourlyResponse.Content.ReadAsStringAsync().Result);

                    string forecastString = "";

                    forecastString += $"| WEEKLY FORECAST: {pointsInfo.properties.relativeLocation.properties.city} - {pointsInfo.properties.relativeLocation.properties.state}\n";
                    foreach (var period in forecastInfo.forecastProperties.periods)
                    {
                        forecastString += $"| {period.name}" +
                                          $"\n| Temperature: {period.temperature} F" +
                                          $"\n| Forecast: {period.detailedForecast}" +
                                          $"\n---------------------------------------------------------------------------------------------------------\n";
                    }


                    forecastString += "\n---------------------------------------------------------------------------------------------------------";
                    forecastString += $"\n| HOURLY FORECAST: {pointsInfo.properties.relativeLocation.properties.city} - {pointsInfo.properties.relativeLocation.properties.state}\n";
                    foreach (var period in hourlyInfo.properties.periods)
                    {
                        forecastString += $"| Hourly: {period.startTime.ToString("yyyy-M-dd hh tt")} - {period.endTime.ToString("hh tt")}" +
                                          $"\n| Temperature: {period.temperature} F" +
                                          $"\n| Forecast: {period.shortForecast}" +
                                          $"\n---------------------------------------------------------------------------------------------------------\n";
                    }


                    return forecastString;
                }
                throw new Exception("You did not enter valid coordiantes, try again.");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
