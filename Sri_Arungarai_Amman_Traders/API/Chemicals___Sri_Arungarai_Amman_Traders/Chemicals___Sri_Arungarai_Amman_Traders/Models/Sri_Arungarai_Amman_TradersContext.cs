﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Chemicals___Sri_Arungarai_Amman_Traders.Models
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

        public virtual DbSet<Chemical> Chemicals { get; set; } = null!;

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
