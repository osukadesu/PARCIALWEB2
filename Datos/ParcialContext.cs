using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
   public class ParcialContext : DbContext
    {
        public ParcialContext(DbContextOptions options) :
            base(options)
        {
            
        }

        public DbSet<Persona> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Proveedor>()
                .HasOne<Persona>()
                .WithMany()
                .HasForeignKey(p => p.Cedula);
        }
    }
}