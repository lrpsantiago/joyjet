using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Joyjet.WebApi.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public IEnumerable<CartItem> Items { get; set; }
    }
}
