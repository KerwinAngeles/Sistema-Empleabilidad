using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Capa_Datos
{
    public partial class PortalEmpleoContext : DbContext
    {
        public PortalEmpleoContext()
        {
        }

        public PortalEmpleoContext(DbContextOptions<PortalEmpleoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Analistum> Analista { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Gerente> Gerentes { get; set; } = null!;
        public virtual DbSet<Notificar> Notificars { get; set; } = null!;
        public virtual DbSet<NotificarSolicitante> NotificarSolicitantes { get; set; } = null!;
        public virtual DbSet<Postulacione> Postulaciones { get; set; } = null!;
        public virtual DbSet<Solicitante> Solicitantes { get; set; } = null!;
        public virtual DbSet<Suscripcion> Suscripcions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vacante> Vacantes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Analistum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contrasena).HasMaxLength(100);

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gerente>(entity =>
            {
                entity.ToTable("Gerente");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contrasena).HasMaxLength(100);

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Notificar>(entity =>
            {
                entity.ToTable("Notificar");

                entity.Property(e => e.Contenido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Notificars)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__Notificar__Empre__4D94879B");
            });

            modelBuilder.Entity<NotificarSolicitante>(entity =>
            {
                entity.ToTable("NotificarSolicitante");

                entity.Property(e => e.Contenido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.Solicitante)
                    .WithMany(p => p.NotificarSolicitantes)
                    .HasForeignKey(d => d.SolicitanteId)
                    .HasConstraintName("FK__Notificar__Solic__60A75C0F");
            });

            modelBuilder.Entity<Postulacione>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cv)
                    .IsUnicode(false)
                    .HasColumnName("CV");

                entity.Property(e => e.EmpresaId).HasColumnName("empresaId");

                entity.Property(e => e.EstadoPostulacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPostulacion).HasColumnType("datetime");

                entity.Property(e => e.SolicitanteId).HasColumnName("SolicitanteID");

                entity.Property(e => e.VacanteId).HasColumnName("VacanteID");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Postulaciones)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__Postulaci__empre__5629CD9C");

                entity.HasOne(d => d.Solicitante)
                    .WithMany(p => p.Postulaciones)
                    .HasForeignKey(d => d.SolicitanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Postulaci__Solic__412EB0B6");

                entity.HasOne(d => d.Vacante)
                    .WithMany(p => p.Postulaciones)
                    .HasForeignKey(d => d.VacanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Postulaci__Vacan__403A8C7D");
            });

            modelBuilder.Entity<Solicitante>(entity =>
            {
                entity.ToTable("Solicitante");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Suscripcion>(entity =>
            {
                entity.ToTable("Suscripcion");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__Suscripci__Empre__5165187F");

                entity.HasOne(d => d.Solicitante)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.SolicitanteId)
                    .HasConstraintName("FK__Suscripci__Solic__5070F446");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCuenta)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vacante>(entity =>
            {
                entity.ToTable("Vacante");

                entity.Property(e => e.VacanteId).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");

                entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Vacantes)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__Vacante__Empresa__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
