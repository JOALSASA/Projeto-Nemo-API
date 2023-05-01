using Microsoft.EntityFrameworkCore;
using Projeto_Nemo.Models;

namespace Projeto_Nemo.Data
{
    public class NemoDbContext : DbContext
    {
        public NemoDbContext(DbContextOptions<NemoDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AquarioParametro>()
                .HasOne(a => a.Aquario)
                .WithMany(ap => ap.AquarioParametros)
                .HasForeignKey(ap => ap.AquariosId);

            modelBuilder.Entity<AquarioParametro>()
               .HasOne(p => p.Parametro)
               .WithMany(ap => ap.AquarioParametros)
               .HasForeignKey(ap => ap.ParametrosId);


            modelBuilder.Entity<UsuarioAquario>()
               .HasOne(u => u.Usuario)
               .WithMany(ua => ua.UsuarioAquarios)
               .HasForeignKey(ua => ua.AquariosId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioAquario>()
               .HasOne(a => a.Aquario)
               .WithMany(ua => ua.UsuarioAquarios)
               .HasForeignKey(ua => ua.UsuariosId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.ListaHistoricos)
                .WithOne(h => h.Usuario)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Aquario> Aquarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<AquarioParametro> AquarioParametros { get; set; }
    }
}
