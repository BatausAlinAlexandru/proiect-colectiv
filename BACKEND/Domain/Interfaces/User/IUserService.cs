using Domain.Entities.User;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        public Task AddUserCredentials(UserAccount user);

        public Task<List<UserAccount>> GetUserAccounts();

        public Task<UserAccount?> GetUserAccountById(Guid id);


    }
}