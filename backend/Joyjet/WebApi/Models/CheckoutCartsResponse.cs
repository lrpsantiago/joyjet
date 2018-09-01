using System.Collections.Generic;

namespace Joyjet.WebApi.Models
{
    public class CheckoutCartsResponse
    {
        public IEnumerable<CartCheckout> Carts { get; set; }
    }
}
