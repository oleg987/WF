using System.Text.Json.Serialization;

namespace WF.Core.Domain
{
    public class Sun
    {
        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }
    }
}
