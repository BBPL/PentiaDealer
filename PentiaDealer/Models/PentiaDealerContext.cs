using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PentiaDealer.Models
{
    public partial class PentiaDealerContext : DbContext
    {
        public PentiaDealerContext()
        {
        }

        public PentiaDealerContext(DbContextOptions<PentiaDealerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarPurchases> CarPurchases { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<SalesPeople> SalesPeople { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PentiaDealer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarPurchases>(entity =>
            {
                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarPurchases)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarPurchases_Cars");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CarPurchases)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarPurchases_Customers");

                entity.HasOne(d => d.SalesPerson)
                    .WithMany(p => p.CarPurchases)
                    .HasForeignKey(d => d.SalesPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarPurchases_SalesPeople");
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.Property(e => e.Color).IsUnicode(false);

                entity.Property(e => e.Extras).IsUnicode(false);

                entity.Property(e => e.Make).IsUnicode(false);

                entity.Property(e => e.Model).IsUnicode(false);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);
            });

            modelBuilder.Entity<SalesPeople>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.JobTitle).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });
        }
    }
}
