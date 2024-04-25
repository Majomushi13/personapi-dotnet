using Microsoft.EntityFrameworkCore;
using personaapi_dotnet.Models;

namespace personaapi_dotnet.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Estudio> Estudios { get; set; }
        public DbSet<Profesion> Profesiones { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la propiedad `Cc` en `Persona`
            modelBuilder.Entity<Persona>()
                .Property(p => p.Cc)
                .ValueGeneratedNever(); // No se genera automáticamente

            // Configura un índice único en `Cc`
            modelBuilder.Entity<Persona>()
                .HasIndex(p => p.Cc)
                .IsUnique();

            // Configuración de la propiedad `Id` en `Profesion`
            modelBuilder.Entity<Profesion>()
                .Property(p => p.Id)
                .ValueGeneratedNever(); // No se genera automáticamente

            // Configura un índice único en `Id` en `Profesion`
            modelBuilder.Entity<Profesion>()
                .HasIndex(p => p.Id)
                .IsUnique();

            // Configuración de la propiedad `Numero` en `Telefono`
            modelBuilder.Entity<Telefono>()
                .Property(t => t.Numero)
                .ValueGeneratedNever(); // No se genera automáticamente

            // Configura un índice único en `Numero` en `Telefono`
            modelBuilder.Entity<Telefono>()
                .HasIndex(t => t.Numero)
                .IsUnique();
        }
    }
}
