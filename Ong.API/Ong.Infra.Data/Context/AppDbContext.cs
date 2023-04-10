using Microsoft.EntityFrameworkCore;
using Ong.Domain.Entities;

namespace Ong.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ParceirosOng> parceiros { get; set; }
    }
}
