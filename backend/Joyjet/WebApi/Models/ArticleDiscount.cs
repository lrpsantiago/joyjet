using Newtonsoft.Json;

namespace Joyjet.WebApi.Models
{
    public enum ArticleDiscountType
    {
        Amount,
        Percentage
    }

    public class ArticleDiscount
    {
        [JsonProperty("article_id")]
        public int ArticleId { get; set; }

        public ArticleDiscountType Type { get; set; }

        public double Value { get; set; }
    }
}
