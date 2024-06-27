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

        }
    }
}
