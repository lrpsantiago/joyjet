using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Joyjet.WebApi.Models
{
    public class CartItem
    {
        [Key]
        [JsonProperty("article_id")]
        public int ArticleId { get; set; }

        public int Quantity { get; set; }
    }
}
