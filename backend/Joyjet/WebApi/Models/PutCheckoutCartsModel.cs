using Joyjet.WebApi.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Joyjet.WebApi.Models
{
    public class PutCheckoutCartsModel
    {
        [RequiredCollection(ErrorMessage = "Articles are required.")]
        public IEnumerable<Article> Articles { get; set; }

        [RequiredCollection(ErrorMessage = "Carts are required.")]
        public IEnumerable<Cart> Carts { get; set; }

        [RequiredCollection(ErrorMessage = "Delivery Fees are required.")]
        [JsonProperty("delivery_fees")]
        public IEnumerable<DeliveryFees> DeliveryFees { get; set; }

        [RequiredCollection(ErrorMessage = "Discounts are required.")]
        public IEnumerable<ArticleDiscount> Discounts { get; set; }
    }
}
