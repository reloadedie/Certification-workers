using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Certification_workers.LocalDB
{
    public partial class CetrificationWorkersContext : DbContext
    {
        public CetrificationWorkersContext()
        {
        }

        public CetrificationWorkersContext(DbContextOptions<CetrificationWorkersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Certified> Certifieds { get; set; } = null!;
        public virtual DbSet<Organization> Organizations { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KIC205I\\SQLEXPRESS;Database=CetrificationWorkers;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certified>(entity =>
            {
                entity.ToTable("Certified");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TypeCertifiedName).HasMaxLength(50);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrganizationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("Worker");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCertified).HasColumnType("date");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupSpeciality)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdOrganization).HasColumnName("idOrganization");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCertifiedNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.IdCertified)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_Certified");

                entity.HasOne(d => d.IdOrganizationNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.IdOrganization)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_Organization");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
