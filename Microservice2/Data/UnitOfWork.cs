using Microservice2.Interfaces;
using Microservice2.Repositories;

namespace Microservice2.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserContext _context;
        public UnitOfWork(UserContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
