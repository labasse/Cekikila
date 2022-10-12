using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CekikilaBack.Models
{
    public partial class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Emprunt> Emprunts { get; set; } = null!;
        public virtual DbSet<Objet> Objets { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emprunt>(entity =>
            {
                entity.HasKey(e => e.IdEmprunt);

                entity.ToTable("Emprunt");

                entity.Property(e => e.Debut).HasColumnType("date");

                entity.Property(e => e.Duree).HasDefaultValueSql("((5))");

                entity.Property(e => e.FinEffective).HasColumnType("date");

                entity.Property(e => e.MailEmprunteur)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.HasOne(d => d.IdObjetNavigation)
                    .WithMany(p => p.Emprunts)
                    .HasForeignKey(d => d.IdObjet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emprunt_Objet");
            });

            modelBuilder.Entity<Objet>(entity =>
            {
                entity.HasKey(e => e.IdObjet);

                entity.ToTable("Objet");

                entity.Property(e => e.Debut).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.DureeMax).HasDefaultValueSql("((10))");

                entity.Property(e => e.Fin).HasColumnType("date");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Valeur)
                    .HasColumnType("decimal(18, 1)")
                    .HasDefaultValueSql("((1.0))");

                entity.HasMany(d => d.IdTags)
                    .WithMany(p => p.IdObjets)
                    .UsingEntity<Dictionary<string, object>>(
                        "TagObjet",
                        l => l.HasOne<Tag>().WithMany().HasForeignKey("IdTag").HasConstraintName("FK_TagObjet_Tag"),
                        r => r.HasOne<Objet>().WithMany().HasForeignKey("IdObjet").HasConstraintName("FK_TagObjet_Objet"),
                        j =>
                        {
                            j.HasKey("IdObjet", "IdTag").HasName("PK__TagObjet__EC2E70EA9A23420B");

                            j.ToTable("TagObjet");
                        });
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.IdTag);

                entity.ToTable("Tag");

                entity.Property(e => e.Label)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
