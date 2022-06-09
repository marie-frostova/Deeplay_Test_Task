using Deeplay_EnterprisePersonnelAccounting.Models;
using Microsoft.EntityFrameworkCore;

namespace Deeplay_EnterprisePersonnelAccounting.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
    }
}