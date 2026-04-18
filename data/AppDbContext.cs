using Microsoft.EntityFrameworkCore;

namespace data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<models.Utente> Utenti => Set<models.Utente>();
        public DbSet<models.Libro> Libri => Set<models.Libro>();
        public DbSet<models.Noleggio> Noleggi => Set<models.Noleggio>();

    }
}
