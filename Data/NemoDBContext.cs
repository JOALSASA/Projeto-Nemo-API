using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Nemo.Models;
using Projeto_Nemo.Models.Enums;

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
            // Configurações de Entidade
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
            
            modelBuilder.Entity<Aquario>()
                .HasMany(u => u.Alertas)
                .WithOne(h => h.Aquario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(u => u.NomeUsuario).IsUnique();
            
            modelBuilder
                .Entity<Parametro>()
                .Property(p => p.Tipo)
                .HasConversion(new EnumToStringConverter<TipoParametro>());
            
            modelBuilder
                .Entity<Alerta>()
                .Property(a => a.EstadoAlerta)
                .HasConversion(new EnumToStringConverter<EstadoAlerta>());

            // Configurações de propriedades
            modelBuilder.Entity<Usuario>().Property(u => u.NomeUsuario).HasMaxLength(100).IsRequired();
        }

        public DbSet<Aquario> Aquarios { get; set; } = default!;
        public DbSet<Usuario> Usuarios { get; set; } = default!;
        public DbSet<Historico> Historicos { get; set; } = default!;
        public DbSet<Parametro> Parametros { get; set; } = default!;
        public DbSet<Perfil> Perfis { get; set; } = default!;
        public DbSet<Alerta> Alertas { get; set; } = default!;
        public DbSet<AquarioParametro> AquarioParametros { get; set; } = default!;
    }
}
