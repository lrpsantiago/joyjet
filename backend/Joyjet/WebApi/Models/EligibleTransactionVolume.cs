using Newtonsoft.Json;

namespace Joyjet.WebApi.Models
{
    public class EligibleTransactionVolume
    {
        [JsonProperty("min_price")]
        public double MinPrice { get; set; }

        [JsonProperty("max_price")]
        public double? MaxPrice { get; set; }
    }
}