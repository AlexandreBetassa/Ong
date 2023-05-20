using Microsoft.EntityFrameworkCore;
using Ong.Domain.Entities;

namespace Ong.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ParceiroOng> Parceiros { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Adocao> PedidosAdocao { get; set; }
    }
}
