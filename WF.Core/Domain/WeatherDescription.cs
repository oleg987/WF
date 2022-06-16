using System.Text.Json.Serialization;

namespace WF.Core.Domain
{
    public class WeatherDescription
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
