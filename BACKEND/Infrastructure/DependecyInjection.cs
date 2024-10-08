using Domain.Interfaces;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=LibraryDB;Integrated Security=True;Trust Server Certificate=True"));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}