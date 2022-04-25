using Microservice1.Models;
using Microsoft.EntityFrameworkCore;
namespace Microservice1.Data
{
    public class CellPhoneContext : DbContext
    {
        public DbSet<CellPhone> Cellphones { get; set; }
        public CellPhoneContext(DbContextOptions options) : base(options)
        {
        }
    }
}
