using Domain.Entities.UserAggregate;
using Domain.Interfaces;

namespace Domain.Entities.User
{
    public class UserAccount : BaseEntity, IAggregateRoot
    {
        public UserAccountCredentials UserAccountCredentials {  get; set; }
        public UserAccountSettings UserAccountSettings { get; set; }

        public UserAccount()
        {
            UserAccountCredentials = new UserAccountCredentials();
            UserAccountSettings = new UserAccountSettings();
        }

        public void AddUserAccountCredentials(string email, string password)
        {
            UserAccountCredentials.Email = email;
            UserAccountCredentials.Password = password;
            UserAccountCredentials.Role = Roles.USER;
        }

        public void AddUserAccountCredentials(UserAccountCredentials userAccountCredentials)
        {
            UserAccountCredentials = userAccountCredentials;
        }

        public void UpdateUserAccountEmail(string email)
        { 
            UserAccountCredentials.Email = email; 
        }

        public void UpdateUserAccountPassowrd(string password)
        {
            UserAccountCredentials.Password = password;
        }

        public void UpdateUserAccountRole(Roles role)
        {
            UserAccountCredentials.Role = role;
        }

        public void AddUserAccountSettings(string test)
        {
            UserAccountSettings.Test = test;
        }


        public UserAccountCredentials GetUserAccountCredentials()
        {
            return UserAccountCredentials;
        }

    }
    public enum Roles
    {
        USER,
        ADMIN,
        MODERATOR
    }
}