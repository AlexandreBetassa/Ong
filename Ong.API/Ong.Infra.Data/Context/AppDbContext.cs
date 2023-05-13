using Microsoft.EntityFrameworkCore;
using Ong.Domain.Entities;

namespace Ong.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ParceiroOng> parceiros { get; set; }
        public DbSet<Noticia> noticias { get; set; }
    }
}
