using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;

namespace Infrastructure.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _repositoryContext;

        public UserRepository(ApplicationContext repositoryContext)
        {
            _repositoryContext = repositoryContext; ;
        }

        public async Task<List<UserAccount>> GetUserAccountsAsync()
        {
            return await _repositoryContext.Users.ToListAsync();
        }

        public async Task AddUserAccountAsync(UserAccount userCredentials)
        {
            _repositoryContext.Users.Add(userCredentials);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<UserAccount?> GetUserAccountById(Guid idAccount)
        {
            return await _repositoryContext.Users.FindAsync(idAccount);
        }

        public async Task UpdateEmailUserAccountAsync(Guid idAccount, string emailAccount)
        {
            var account = await _repositoryContext.Users.FindAsync(idAccount);
            if (account != null)
            {
                account.Email = emailAccount;
                await _repositoryContext.SaveChangesAsync();
            }
        }

        public async Task UpdatePasswordUserAccountAsync(Guid idAccount, string passwordAccount)
        {
            var account = await _repositoryContext.Users.FindAsync(idAccount);
            if (account != null)
            {
                account.Password = passwordAccount;
                await _repositoryContext.SaveChangesAsync();
            }
        }

        public async Task UpdateRoleUserAccountAsync(Guid idAccount, Role roleAccount)
        {
            var account = await _repositoryContext.Users.FindAsync(idAccount);
            if (account != null)
            {
                account.Role = roleAccount;
                await _repositoryContext.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAccountAsync(Guid idAccount)
        {
            var account = _repositoryContext.Users.FindAsync(idAccount);
            _repositoryContext.Remove(account);
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
