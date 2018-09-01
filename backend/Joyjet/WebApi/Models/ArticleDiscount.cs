using Newtonsoft.Json;

namespace Joyjet.WebApi.Models
{
    public class ArticleDiscount
    {
        [JsonProperty("article_id")]
        public int ArticleId { get; set; }

        public DiscountType Type { get; set; }

        public double Value { get; set; }
    }

    public enum DiscountType
    {
        Amount,
        Percentage
    }
}
