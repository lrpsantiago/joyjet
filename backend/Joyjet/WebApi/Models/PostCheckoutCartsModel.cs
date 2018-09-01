using System.Collections.Generic;

namespace Joyjet.WebApi.Models
{
    public class PostCheckoutCartsModel
    {
        public IEnumerable<Article> Articles { get; set; }

        public IEnumerable<Cart> Carts { get; set; }
    }
}
