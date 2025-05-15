using challenger.Domain.Entities;
using challenger.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace challenger.Infrastructure.Context
{
    public class CGContext(DbContextOptions<CGContext> options) : DbContext(options)
    {
        public DbSet<Moto> Motos { get; set; }

        public DbSet<Patio> Patios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatioMapping());
            modelBuilder.ApplyConfiguration(new MotoMapping());
        }
    }
}
