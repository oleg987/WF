using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.Core.Domain;

namespace WF.Core.Mappings
{
    public class ForecastProfile : Profile
    {
        public ForecastProfile()
        {
            CreateMap<OpenWeatherResponse, Foreast>()
                .ForMember(d => d.City, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.FeelsLike, opt => opt.MapFrom(s => s.Indicators.FeelsLike))
                .ForMember(d => d.Pressure, opt => opt.MapFrom(s => s.Indicators.Pressure))
                .ForMember(d => d.Temperature, opt => opt.MapFrom(s => s.Indicators.Temperature))
                .ForMember(d => d.Humidity, opt => opt.MapFrom(s => s.Indicators.Humidity))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => string.Join(", ", s.Weather.Select(wd => wd.Description))))
                .ForMember(d => d.Gust, opt => opt.MapFrom(s => s.Wind.Gust))
                .ForMember(d => d.WindSpeed, opt => opt.MapFrom(s => s.Wind.Speed))
                .ForMember(d => d.WindDirection, opt => opt.MapFrom(s => s.Wind.Direction))
                .ForMember(d => d.Sunrise, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.Sun.Sunrise).AddSeconds(s.Timezone).DateTime))
                .ForMember(d => d.Sunset, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.Sun.Sunset + s.Timezone).DateTime));   
        }
    }
}
