using Microservice2.Models;

namespace Microservice2.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddNewUserAsync(User user);
        bool RemoveUser(User user);
        bool UpdateUser(User user);
        Task<List<User>> ListAllUsersAsync();
        Task<User> FindUserAsync(int id);
    }
}
