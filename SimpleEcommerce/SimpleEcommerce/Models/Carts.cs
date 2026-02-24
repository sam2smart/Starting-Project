using System.ComponentModel.DataAnnotations;

namespace SimpleEcommerce.Models
{
    public class Carts
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public Product? Product { get; set; }
    }
}
