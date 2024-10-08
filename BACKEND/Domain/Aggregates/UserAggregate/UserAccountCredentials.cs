using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.Entities.UserAggregate
{
    public class UserAccountCredentials
    {

        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public Roles Role { get; set; }
    }
}
