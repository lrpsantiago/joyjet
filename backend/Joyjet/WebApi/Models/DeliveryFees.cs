using Newtonsoft.Json;

namespace Joyjet.WebApi.Models
{
    public class DeliveryFees
    {
        [JsonProperty("eligible_transaction_volume")]
        public EligibleTransactionVolume EligibleTransactionVolume { get; set; }

        public double Price { get; set; }
    }
}