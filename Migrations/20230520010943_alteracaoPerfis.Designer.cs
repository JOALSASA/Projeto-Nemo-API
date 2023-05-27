﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Nemo.Data;

#nullable disable

namespace Projeto_Nemo.Migrations
{
    [DbContext(typeof(NemoDbContext))]
    [Migration("20230520010943_alteracaoPerfis")]
    partial class alteracaoPerfis
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PerfilUsuario", b =>
                {
                    b.Property<int>("PerfisId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("PerfisId", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("PerfilUsuario");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.Aquario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Altura")
                        .HasColumnType("int");

                    b.Property<int>("Comprimento")
                        .HasColumnType("int");

                    b.Property<int>("Largura")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Aquarios");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.AquarioParametro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AquariosId")
                        .HasColumnType("int");

                    b.Property<int>("ParametrosId")
                        .HasColumnType("int");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AquariosId");

                    b.HasIndex("ParametrosId");

                    b.ToTable("AquarioParametros");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.Historico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AquarioParametroId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AquarioParametroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Historicos");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.Parametro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Max")
                        .HasColumnType("int");

                    b.Property<int>("Min")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parametros");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NomeUsuario")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.UsuarioAquario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AquariosId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AquariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("UsuarioAquario");
                });

            modelBuilder.Entity("PerfilUsuario", b =>
                {
                    b.HasOne("Projeto_Nemo.Models.Perfil", null)
                        .WithMany()
                        .HasForeignKey("PerfisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Nemo.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projeto_Nemo.Models.Aquario", b =>
                {
                    b.HasOne("Projeto_Nemo.Models.Usuario", "Usuario")
                        .WithMany("ListaAquarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.AquarioParametro", b =>
                {
                    b.HasOne("Projeto_Nemo.Models.Aquario", "Aquario")
                        .WithMany("AquarioParametros")
                        .HasForeignKey("AquariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Nemo.Models.Parametro", "Parametro")
                        .WithMany("AquarioParametros")
                        .HasForeignKey("ParametrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aquario");

                    b.Navigation("Parametro");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.Historico", b =>
                {
                    b.HasOne("Projeto_Nemo.Models.AquarioParametro", "AquarioParametro")
                        .WithMany("Historicos")
                        .HasForeignKey("AquarioParametroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Nemo.Models.Usuario", "Usuario")
                        .WithMany("ListaHistoricos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AquarioParametro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.UsuarioAquario", b =>
                {
                    b.HasOne("Projeto_Nemo.Models.Usuario", "Usuario")
                        .WithMany("UsuarioAquarios")
                        .HasForeignKey("AquariosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Projeto_Nemo.Models.Aquario", "Aquario")
                        .WithMany("UsuarioAquarios")
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aquario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.Aquario", b =>
                {
                    b.Navigation("AquarioParametros");

                    b.Navigation("UsuarioAquarios");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.AquarioParametro", b =>
                {
                    b.Navigation("Historicos");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.Parametro", b =>
                {
                    b.Navigation("AquarioParametros");
                });

            modelBuilder.Entity("Projeto_Nemo.Models.Usuario", b =>
                {
                    b.Navigation("ListaAquarios");

                    b.Navigation("ListaHistoricos");

                    b.Navigation("UsuarioAquarios");
                });
#pragma warning restore 612, 618
        }
    }
}
