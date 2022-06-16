using System.Text.Json.Serialization;

namespace WF.Core.Domain
{
    public class Clouds
    {
        [JsonPropertyName("all")]
        public double All { get; set; }
    }
}
