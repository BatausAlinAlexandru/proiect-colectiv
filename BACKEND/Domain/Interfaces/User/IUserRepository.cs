using Domain.Entities.User;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<UserAccount>> GetUserAccountsAsync();
        public Task<UserAccount?> GetUserAccountById(Guid idAccount);

        public Task AddUserAccountAsync(UserAccount userCredentials);
        public Task UpdateEmailUserAccountAsync(Guid idAccount, string emailAccount);
        public Task UpdatePasswordUserAccountAsync(Guid idAccount, string passwordAccount);
        public Task UpdateRoleUserAccountAsync(Guid idAccount, Role roleAccouont);
        public Task DeleteUserAccountAsync(Guid idAccount);
    }
}
