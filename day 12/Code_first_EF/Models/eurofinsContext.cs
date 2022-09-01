using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Code_first_EF.Models
{
    public partial class eurofinsContext : DbContext
    {
        public eurofinsContext()
        {
        }

        public eurofinsContext(DbContextOptions<eurofinsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bonu> Bonus { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<DeliveryPartner> DeliveryPartners { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Fee> Fees { get; set; } = null!;
        public virtual DbSet<Sbaccount> Sbaccounts { get; set; } = null!;
        public virtual DbSet<Sbtransaction> Sbtransactions { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Title> Titles { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=eurofins;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bonu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bonus");

                entity.Property(e => e.BonusAmount).HasColumnName("bonus_amount");

                entity.Property(e => e.BonusDate)
                    .HasColumnType("date")
                    .HasColumnName("bonus_date");

                entity.Property(e => e.WorkerRefId).HasColumnName("worker_ref_id");

                entity.HasOne(d => d.WorkerRef)
                    .WithMany()
                    .HasForeignKey(d => d.WorkerRefId)
                    .HasConstraintName("FK__bonus__worker_re__44FF419A");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cars");

                entity.Property(e => e.CarId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("car_id");

                entity.Property(e => e.CarName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("car_name");

                entity.Property(e => e.CarType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("car_type");

                entity.Property(e => e.OwnerId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("owner_id");
            });

            modelBuilder.Entity<DeliveryPartner>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("delivery_partners");

                entity.Property(e => e.PartnerId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("partner_id");

                entity.Property(e => e.PartnerName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("partner_name");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.Rating).HasColumnName("rating");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("department");

                entity.Property(e => e.DepartmentBlockNumber).HasColumnName("department_block_number");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("department_name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employee");

                entity.Property(e => e.Dept)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dept");

                entity.Property(e => e.Eid).HasColumnName("eid");

                entity.Property(e => e.Ename)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ename");

                entity.Property(e => e.Gender)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Joiningdate)
                    .HasColumnType("date")
                    .HasColumnName("joiningdate");

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Salary)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("salary");
            });

            modelBuilder.Entity<Fee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("fees");

                entity.Property(e => e.Amountpaid).HasColumnName("amountpaid");

                entity.Property(e => e.Dept)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("dept");

                entity.Property(e => e.Regno).HasColumnName("regno");
            });

            modelBuilder.Entity<Sbaccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SBAccount");

                entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sbtransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SBTransaction");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TransactionDate)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("student");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Regno).HasColumnName("regno");

                entity.Property(e => e.Sname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sname");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => e.WorkerRefId)
                    .HasName("PK__title__57E25DD2B8C11F1B");

                entity.ToTable("title");

                entity.Property(e => e.WorkerRefId)
                    .ValueGeneratedNever()
                    .HasColumnName("worker_ref_id");

                entity.Property(e => e.AffectedFrom)
                    .HasColumnType("date")
                    .HasColumnName("affected_from");

                entity.Property(e => e.WorkerTitle)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("worker_title");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("worker");

                entity.Property(e => e.WorkerId)
                    .ValueGeneratedNever()
                    .HasColumnName("worker_id");

                entity.Property(e => e.Dapartment)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dapartment");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("date")
                    .HasColumnName("joining_date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
