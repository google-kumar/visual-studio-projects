using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_EF_eg.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Logintable> Logintables { get; set; } = null!;
        public virtual DbSet<Salary> Salaries { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Tuitor> Tuitors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=shrivalli_tuition_center;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logintable>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("logintable");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("salaries");

                entity.Property(e => e.EmployeeNo).HasColumnName("employee_no");

                entity.Property(e => e.Salary1).HasColumnName("salary");

                entity.Property(e => e.TuitorName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tuitor_name");

                entity.HasOne(d => d.TuitorNameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.TuitorName)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__salaries__tuitor__286302EC");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.RollNo)
                    .HasName("PK__student__9560EEE105736867");

                entity.ToTable("student");

                entity.HasIndex(e => e.PhoneNum, "check_phone_no1")
                    .IsUnique();

                entity.Property(e => e.RollNo).HasColumnName("roll_no");

                entity.Property(e => e.Course)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("course");

                entity.Property(e => e.PhoneNum).HasColumnName("phone_num");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("student_name");

                entity.Property(e => e.Tuitor)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tuitor");

                entity.HasOne(d => d.TuitorNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Tuitor)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__student__tuitor__267ABA7A");
            });

            modelBuilder.Entity<Tuitor>(entity =>
            {
                entity.HasKey(e => e.TuitorName)
                    .HasName("PK__tuitor__F64209686E4ECCAD");

                entity.ToTable("tuitor");

                entity.HasIndex(e => e.Course, "check_course1")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNum, "check_phone_no1_2")
                    .IsUnique();

                entity.Property(e => e.TuitorName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tuitor_name");

                entity.Property(e => e.Course)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("course");

                entity.Property(e => e.EmployeeNo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("employee_no");

                entity.Property(e => e.PhoneNum).HasColumnName("phone_num");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
