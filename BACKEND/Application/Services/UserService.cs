using Domain.Entities.User;
using BCrypt.Net;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    internal class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task AddUserCredentials(UserAccount user)
        {
            
            user.UserAccountCredentials.Password = BCrypt.Net.BCrypt.HashPassword(user.UserAccountCredentials.Password);
            await _repository.AddUserAccountAsync(user);
        }

        public async Task<List<UserAccount>> GetUserAccounts()
        {
            return await _repository.GetUserAccountsAsync();
        }

        public async Task<UserAccount?> GetUserAccountById(Guid idAccount)
        {
            return await _repository.GetUserAccountById(idAccount);
        }


    }
}
