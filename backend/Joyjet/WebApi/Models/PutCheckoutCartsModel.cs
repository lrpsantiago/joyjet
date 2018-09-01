using Newtonsoft.Json;
using System.Collections.Generic;

namespace Joyjet.WebApi.Models
{
    public class PutCheckoutCartsModel
    {
        public IEnumerable<Article> Articles { get; set; }

        public IEnumerable<Cart> Carts { get; set; }

        [JsonProperty("delivery_fees")]
        public IEnumerable<DeliveryFees> DeliveryFees { get; set; }

        public IEnumerable<ArticleDiscount> Discounts { get; set; }
    }
}
