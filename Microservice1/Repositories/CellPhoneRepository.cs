using Microservice1.Data;
using Microservice1.Interfaces;
using Microservice1.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice1.Repositories
{
    public class CellPhoneRepository : ICellPhoneRepository
    {
        private readonly CellPhoneContext _context;
        public CellPhoneRepository(CellPhoneContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewCellphoneAsync(CellPhone cellphone)
        {
            try
            {
                await _context.Cellphones.AddAsync(cellphone);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CellPhone> FindCellphoneAsync(int id)
        {
            return await _context.Cellphones.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CellPhone>> ListAllCellphonesAsync()
        {
            return await _context.Cellphones.ToListAsync();
        }

        public bool RemoveCellphone(CellPhone cellphone)
        {
            try
            {
                _context.Cellphones.Remove(cellphone);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCellphone(CellPhone cellphone)
        {
            try
            {
                _context.Cellphones.Update(cellphone);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
