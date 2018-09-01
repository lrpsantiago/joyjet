using Newtonsoft.Json;

namespace Joyjet.WebApi.Models
{
    public class CartItem
    {
        [JsonProperty("article_id")]
        public int ArticleId { get; set; }

        public int Quantity { get; set; }
    }
}
