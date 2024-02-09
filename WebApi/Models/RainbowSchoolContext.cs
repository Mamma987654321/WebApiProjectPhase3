using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Models
{
    public partial class RainbowSchoolContext : DbContext
    {
        public RainbowSchoolContext()
        {
        }

        public RainbowSchoolContext(DbContextOptions<RainbowSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-MANASA;database=RainbowSchool;trusted_connection=true; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("classes");

                entity.Property(e => e.ClassId)
                    .ValueGeneratedNever()
                    .HasColumnName("classId");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.HasIndex(e => e.ClassId, "IX_Students_ClaasId");

                entity.HasIndex(e => e.LastName, "IX_Students_LastName");

                entity.Property(e => e.StudentId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasIndex(e => e.SubjectName, "IX_Students_SubjectName");

                entity.Property(e => e.SubjectId).ValueGeneratedNever();

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
