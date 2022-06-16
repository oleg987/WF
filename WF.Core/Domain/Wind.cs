using System.Text.Json.Serialization;

namespace WF.Core.Domain
{
    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        [JsonPropertyName("deg")]
        public double Direction { get; set; }

        [JsonPropertyName("gust")]
        public double Gust { get; set; }
    }
}
