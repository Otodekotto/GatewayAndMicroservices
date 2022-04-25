using Microservice2.Data;
using Microservice2.Interfaces;
using Microservice2.Models;

namespace Microservice2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewUserAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> FindUserAsync(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<User>> ListAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public bool RemoveUser(User user)
        {
            try
            {
                _context.Users.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}