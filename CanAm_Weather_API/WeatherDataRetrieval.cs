using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CanAm_Weather_API
{
    public class WeatherDataRetrieval
    {
        private int _testInt;
        private string _testStr;
        private HttpClient _httpClient = new HttpClient();


        public WeatherDataRetrieval() 
        {
            _testInt = 0;
            _testStr = "test";

            //valid state codes
            //[ AL, AK, AS, AR, AZ, CA, CO, CT, DE, DC, FL, GA, GU, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, PR, RI, SC, SD, TN, TX, UT, VT, VI, VA, WA, WV, WI, WY, MP, PW, FM, MH ]
        }

        public async Task<string> GetEntitiesAsync(string state)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.weather.gov/stations?state=CO&limit=500");

                var appValue = new ProductInfoHeaderValue("CanAm_Weather_Exercise", "1.0");
                var emailValue = new ProductInfoHeaderValue("(+CanAmWeatherExercise@gmail.com)");

                request.Headers.UserAgent.Add(appValue);
                request.Headers.UserAgent.Add(emailValue);

                var response = await _httpClient.SendAsync(request);

                //HttpResponseMessage response = await _httpClient.GetAsync("https://api.weather.gov/stations?state=CO&limit=500");

                Console.WriteLine("Content: " + response.Content);

                return response.Content.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return "failed";
        }


    }
}
