using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using WF.Core.Domain;
using AutoMapper;
using WF.Core.Mappings;

namespace WF.Core.Service
{
    public class WeatherService : IWeatherService
    {
        private HttpClient _client;
        private Mapper _mapper;
        private string _key;

        public WeatherService(string key)
        {
            _client = new HttpClient();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new ForecastProfile())));
            _key = key;
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public Foreast Get(string city)
        {
            var response = _client.GetAsync($@"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={_key}").Result;

            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;

                var weather = JsonSerializer.Deserialize<OpenWeatherResponse>(data); // TODO: Handle Exception.

                var forecast = _mapper.Map<Foreast>(weather); // TODO: Handle Exception.

                return forecast;
            }
            else
            {
                return null; // TODO: Throw Exception.
            }
        }
    }
}
