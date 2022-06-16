using System;
using WF.Core.Service;

namespace WF
{    
    internal class Program
    {
        private const string KEY = "c16337ebad8860ce112d59b2d00ff139";

        static void Main(string[] args)
        {            
            using IWeatherService service = new WeatherServiceProxy(KEY);

            var forecast = service.Get("Odessa");
            forecast = service.Get("Odessa");

            var presentation =
                $"City: {forecast.City}\r\n" +
                $"{forecast.Description}\r\n" +
                $"Temperature: {forecast.Temperature}\r\n" +
                $"Wind: Speed - {forecast.WindSpeed}; Direction - {forecast.WindDirection};\r\n" +
                $"Sunrise: {forecast.Sunrise}\r\n" +
                $"Sunset: {forecast.Sunset}";

            Console.WriteLine(presentation);
        }
    }
}
