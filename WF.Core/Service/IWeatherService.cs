using System;
using WF.Core.Domain;

namespace WF.Core.Service
{
    public interface IWeatherService : IDisposable
    {
        Foreast Get(string city);
    }
}