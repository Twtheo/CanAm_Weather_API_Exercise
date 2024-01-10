global using System.Net.Http.Headers;

namespace CanAm_Weather_API
{

    /*
        
        Software Engineering staff at Can/Am are often tasked with developing integrations against a real-time API. In this exercise, you will write a simple application that retrieves weather forecast information for a particular zone or weather station and presents it in a nicely formatted way. Here are the key requirements:

        1. Use data from the National Weather Service API: 
        https://www.weather.gov/documentation/services-web-api#/default/office
        2. Allow the user to input a State (e.g., CO) and retrieve a list of local entities - e.g., zones, weather stations - from which forecast data can be accessed.
        3. Present a detailed forecast based on a specific local entity or set of coordinates. You can decide what API service to use to pull forecast information, as well as how to present your data; there are several options available in the API. However, you should present the data in a way that makes it easy to see hourly or daily forecasts with temperature highs/lows.
        4. Feel free to use the programming language of your choice - C#, Python, etc.

        Once you are done, send me your source code and the amount of time you spent on the exercise.
     */
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter a state using it's state code eg. 'CO' for Colorado: ");
                string state = Console.ReadLine();

                WeatherDataRetrieval weatherDataRetrieval = new WeatherDataRetrieval();

                var result = await weatherDataRetrieval.GetEntitiesAsync(state);

                Console.WriteLine("end Test");

            } catch (Exception ex)
            {
                Console.WriteLine("Exception encountered!");
                Console.WriteLine(ex.Message);
            }

        }
    }
}