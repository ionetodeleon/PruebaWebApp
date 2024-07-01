using Microsoft.EntityFrameworkCore;
using PruebaWebApp.Models;

namespace PruebaWebApp.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Oficina> Oficinas { get; set; }
        public DbSet<UsuarioProyecto> UsuarioProyectos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioProyecto>().HasKey(up => new { up.IdUsuario, up.IdProyecto });

            modelBuilder.Entity<UsuarioProyecto>()
                .HasOne(up => up.Usuario)
                .WithMany(u => u.UsuarioProyectos)
                .HasForeignKey(up => up.IdUsuario);

            modelBuilder.Entity<UsuarioProyecto>()
                .HasOne(up => up.Proyecto)
                .WithMany(p => p.UsuarioProyectos)
                .HasForeignKey(up => up.IdProyecto);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Categoria)
                .WithMany(c => c.Usuarios)
                .HasForeignKey(u => u.CategoriaId);

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Estandar", Descripcion = "Categoria normal" },
                new Categoria { Id = 2, Nombre = "Premium", Descripcion = "Categoria premium" }
                );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nombre = "Juan", Apellido = "Perez", Cedula = "12345678", CategoriaId = 1 },
                new Usuario { Id = 2, Nombre = "Maria", Apellido = "Gomez", Cedula = "87654321", CategoriaId = 2 }
                );

            modelBuilder.Entity<Oficina>().HasData(
                new Oficina { Id = 1, Nombre = "Oficina 1", Direccion = "Calle 123", UsuarioId = 1 },
                new Oficina { Id = 2, Nombre = "Oficina 2", Direccion = "Avenida 456" }
            );

            modelBuilder.Entity<Proyecto>().HasData(
                new Proyecto { Id = 1, Nombre = "Proyecto 1", Descripcion = "Descripción del Proyecto 1" },
                new Proyecto { Id = 2, Nombre = "Proyecto 2", Descripcion = "Descripción del Proyecto 2" }
            );

            modelBuilder.Entity<UsuarioProyecto>().HasData(
                new UsuarioProyecto { IdUsuario = 1, IdProyecto = 1 },
                new UsuarioProyecto { IdUsuario = 1, IdProyecto = 2 },
                new UsuarioProyecto { IdUsuario = 2, IdProyecto = 1 }
            );
        }
    }
}
