using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sri_Arungarai_Amman_Traders.Models
{
    public partial class Sri_Arungarai_Amman_TradersContext : DbContext
    {
        public Sri_Arungarai_Amman_TradersContext()
        {
        }

        public Sri_Arungarai_Amman_TradersContext(DbContextOptions<Sri_Arungarai_Amman_TradersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminLogin> AdminLogins { get; set; } = null!;
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Billing> Billings { get; set; } = null!;
        public virtual DbSet<Chemical> Chemicals { get; set; } = null!;
        public virtual DbSet<Fertilizer> Fertilizers { get; set; } = null!;
        //public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<Seed> Seeds { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Sri_Arungarai_Amman_Traders;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminLogin>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__Admin_Lo__C9F284576BA5FFAA");

                entity.ToTable("Admin_Login");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.BillNo)
                    .HasName("PK__tmp_ms_x__11F284196A510B46");

                entity.Property(e => e.BillDate)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Billing>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("PK__Billings__5E5A535FB208DB57");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductType)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Chemical>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Chemical__B40CC6ED54179D3A");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductUnit)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fertilizer>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Fertiliz__B40CC6EDBE87843B");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductUnit)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            //modelBuilder.Entity<ProductType>(entity =>
            //{
            //    entity.Property(e => e.ProductTypeId).ValueGeneratedNever();

            //    entity.Property(e => e.ProductTypeName)
            //        .HasMaxLength(20)
            //        .IsFixedLength();
            //});

            modelBuilder.Entity<Seed>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Seeds__B40CC6ED02FC25B9");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductUnit)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__User_Log__C9F284570A1C6BB7");

                entity.ToTable("User_Login");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
