using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_API_Client.Models
{
    public partial class shrivalli_tuition_centerContext : DbContext
    {
        public shrivalli_tuition_centerContext()
        {
        }

        public shrivalli_tuition_centerContext(DbContextOptions<shrivalli_tuition_centerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;

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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
