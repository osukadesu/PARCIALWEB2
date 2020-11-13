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

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Vacuna> Vacunas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Estudiante>()
                .HasOne<Persona>()
                .WithMany()
                .HasForeignKey(p => p.Cedula);

            modelBuilder
                .Entity<Vacuna>()
                .HasOne<Estudiante>()
                .WithMany()
                .HasForeignKey(p => p.Cedula);
        }
    }
}
