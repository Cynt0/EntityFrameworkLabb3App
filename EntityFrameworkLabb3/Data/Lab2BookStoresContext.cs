using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EntityFrameworkLabb3.Models;

namespace EntityFrameworkLabb3.Data
{
    public partial class Lab2BookStoresContext : DbContext
    {
        public Lab2BookStoresContext()
        {
        }

        public Lab2BookStoresContext(DbContextOptions<Lab2BookStoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anställda> Anställda { get; set; } = null!;
        public virtual DbSet<Butiker> Butiker { get; set; } = null!;
        public virtual DbSet<Böcker> Böcker { get; set; } = null!;
        public virtual DbSet<Författare> Författare { get; set; } = null!;
        public virtual DbSet<FörfattareOchBöcker> FörfattareOchBöcker { get; set; } = null!;
        public virtual DbSet<Kunder> Kunder { get; set; } = null!;
        public virtual DbSet<Lagersaldo> Lagersaldo { get; set; } = null!;
        public virtual DbSet<LagersaldoHemsidum> LagersaldoHemsida { get; set; } = null!;
        public virtual DbSet<OrderSpecarHemsidum> OrderSpecarHemsida { get; set; } = null!;
        public virtual DbSet<Ordrar> Ordrar { get; set; } = null!;
        public virtual DbSet<VyAntalOrdrar> VyAntalOrdrar { get; set; } = null!;
        public virtual DbSet<VyFleraFörfattareSammaBok> VyFleraFörfattareSammaBok { get; set; } = null!;
        public virtual DbSet<VyFörfattareTitlar> VyFörfattareTitlar { get; set; } = null!;
        public virtual DbSet<VyStorKund> VyStorKund { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-P7CUTAQ\\SQLEXPRESS;Initial Catalog=Lab2BookStores;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anställda>(entity =>
            {
                entity.HasOne(d => d.Butiker)
                    .WithMany(p => p.Anställda)
                    .HasForeignKey(d => d.ButikerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Anställda__Butik__44FF419A");
            });

            modelBuilder.Entity<Butiker>(entity =>
            {
                entity.HasOne(d => d.AnställdaNavigation)
                    .WithMany(p => p.Butikers)
                    .HasForeignKey(d => d.AnställdaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Butiker__Anställ__440B1D61");
            });

            modelBuilder.Entity<Böcker>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Författare)
                    .WithMany(p => p.Böckers)
                    .HasForeignKey(d => d.FörfattareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Böcker__Författa__34C8D9D1");
            });

            modelBuilder.Entity<FörfattareOchBöcker>(entity =>
            {
                entity.HasOne(d => d.Författare)
                    .WithMany()
                    .HasForeignKey(d => d.FörfattareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FörfattareOchBöcker_Författare");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FörfattareOchBöcker_Böcker");
            });

            modelBuilder.Entity<Lagersaldo>(entity =>
            {
                entity.HasKey(e => new { e.BöckerIsbn, e.ButikerId });

                entity.HasOne(d => d.Butiker)
                    .WithMany(p => p.Lagersaldos)
                    .HasForeignKey(d => d.ButikerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lagersaldo_Butiker");

                entity.HasOne(d => d.BöckerIsbnNavigation)
                    .WithMany(p => p.Lagersaldos)
                    .HasForeignKey(d => d.BöckerIsbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lagersaldo_Böcker");
            });

            modelBuilder.Entity<LagersaldoHemsidum>(entity =>
            {
                entity.Property(e => e.Antal).IsFixedLength();
            });

            modelBuilder.Entity<OrderSpecarHemsidum>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.Isbn })
                    .HasName("PK_OrderSpecar");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.OrderSpecarHemsida)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderSpecar_Böcker");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderSpecarHemsida)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderSpecar_Ordrar");
            });

            modelBuilder.Entity<Ordrar>(entity =>
            {
                entity.HasOne(d => d.Kund)
                    .WithMany(p => p.Ordrars)
                    .HasForeignKey(d => d.KundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ordrar_Kunder");
            });

            modelBuilder.Entity<VyAntalOrdrar>(entity =>
            {
                entity.ToView("vy_Antal_Ordrar");
            });

            modelBuilder.Entity<VyFleraFörfattareSammaBok>(entity =>
            {
                entity.ToView("vy_FleraFörfattareSammaBok");
            });

            modelBuilder.Entity<VyFörfattareTitlar>(entity =>
            {
                entity.ToView("vy_FörfattareTitlar");
            });

            modelBuilder.Entity<VyStorKund>(entity =>
            {
                entity.ToView("vy_StorKund");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
