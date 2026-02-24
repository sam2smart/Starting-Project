using System.ComponentModel.DataAnnotations;

namespace SimpleEcommerce.Models
{
    public class Users
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
