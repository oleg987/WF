using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.Core.Domain;

namespace WF.Core.Service
{
    public class WeatherServiceProxy : IWeatherService
    {
        private IWeatherService _service;
        private Dictionary<CacheMarker, Foreast> _cache;

        public WeatherServiceProxy(string key)
        {
            _service = new WeatherService(key);
            _cache = new Dictionary<CacheMarker, Foreast>();
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public Foreast Get(string city)
        {
            var marker = new CacheMarker(city);
            if (_cache.Keys.Any(k => k.Equals(marker)))
            {
                return _cache[_cache.Keys.Where(k => k.Equals(marker)).First()];
            }
            else
            {
                var forecast = _service.Get(city);

                _cache.Add(marker, forecast);

                return forecast;
            }            
        }
    }
}
