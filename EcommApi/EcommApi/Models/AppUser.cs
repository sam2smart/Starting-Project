namespace EcommApi.Models
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
    }
}
