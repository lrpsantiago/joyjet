using System.ComponentModel.DataAnnotations;

namespace Joyjet.WebApi.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Price { get; set; }
    }
}
