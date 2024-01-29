using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ABM_Customer.Data.Entities
{
    public partial class CopernicusContext : DbContext
    {
        public CopernicusContext()
        {
        }

        public CopernicusContext(DbContextOptions<CopernicusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.company)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.created).HasColumnType("datetime");

                entity.Property(e => e.email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.first)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.last)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
