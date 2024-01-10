using CanAm_Weather_API_Page.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CanAm_Weather_API_Page.Controllers
{
    namespace CanAm_Weather_API_Page.Models
    {

        [ApiController]
        [Route("api/[controller]/{state}")]
        public class WeatherStationController : ControllerBase
        {
            private readonly HttpClient _httpClient;
            private readonly string[] _stateList = ["AL", "AK", "AS", "AR", "AZ", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "PR", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VI", "VA", "WA", "WV", "WI", "WY", "MP", "PW", "FM", "MH"];

            public WeatherStationController()
            {
                _httpClient = new HttpClient();
            }

            [HttpGet]
            public async Task<ActionResult<Stations>> GetStationDataAsync(string state)
            {
                try
                {
                    state = state.ToUpper();

                    //input sanitize
                    if (!_stateList.Contains(state))
                    {
                        return BadRequest("You must enter a valid state code, here are your options: " + string.Join(",", _stateList));
                    }

                    var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.weather.gov/stations?state={state}&limit=500");

                    var appValue = new ProductInfoHeaderValue("CanAm_Weather_Exercise", "1.0");
                    var emailValue = new ProductInfoHeaderValue("(+CanAmWeatherExercise@gmail.com)");

                    request.Headers.UserAgent.Add(appValue);
                    request.Headers.UserAgent.Add(emailValue);

                    var response = await _httpClient.SendAsync(request);

                    var stationList = JsonConvert.DeserializeObject<Stations>(response.Content.ReadAsStringAsync().Result);

                    return Ok(stationList);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
