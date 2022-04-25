using Microservice1.Interfaces;
using Microservice1.Repositories;

namespace Microservice1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CellPhoneContext _context;
        public UnitOfWork(CellPhoneContext context)
        {
            _context = context;
        }

        public ICellPhoneRepository CellphoneRepository => new CellPhoneRepository(_context);

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
