using System.ComponentModel.DataAnnotations;

namespace Joyjet.WebApi.Models
{
    public class CartCheckout
    {
        [Key]
        public int Id { get; set; }

        public double Total { get; set; }
    }
}
