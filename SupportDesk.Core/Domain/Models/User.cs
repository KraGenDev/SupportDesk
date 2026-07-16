using SupportDesk.Core.Domain.Enums;

namespace SupportDesk.Core.Domain.Models
{
    public class User()
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User PromoutedBy { get; set; }
    }
}
