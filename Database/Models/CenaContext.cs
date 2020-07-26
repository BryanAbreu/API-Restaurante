using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.Models
{
    public partial class CenaContext : DbContext
    {
        public CenaContext()
        {
        }

        public CenaContext(DbContextOptions<CenaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredientes> Ingredientes { get; set; }
        public virtual DbSet<Mesas> Mesas { get; set; }
        public virtual DbSet<Ordenes> Ordenes { get; set; }
        public virtual DbSet<Plato> Plato { get; set; }
        public virtual DbSet<PlatoIngredientes> PlatoIngredientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CO74FS7\\SQLEXPRESS;Database=Cena;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredientes>(entity =>
            {
                entity.Property(e => e.NombreIngrediente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mesas>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ordenes>(entity =>
            {
                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mesa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Platos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plato>(entity =>
            {
                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ingredientes)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePlato)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlatoIngredientes>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.IdIngredienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdIngrediente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlatoIngredientes_Ingredientes");

                entity.HasOne(d => d.IdPlatosNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPlatos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlatoIngredientes_Plato");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
