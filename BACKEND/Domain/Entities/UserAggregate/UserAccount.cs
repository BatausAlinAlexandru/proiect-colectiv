using Domain.Interfaces;

namespace Domain.Entities.User
{
    public class UserAccount : BaseEntity, IAggregateRoot
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public Role Role { get; set; }

        public UserAccount(string password, string email) : base()
        {
            Password = password;
            Email = email;
            Role = Role.USER;
        }
    }

}