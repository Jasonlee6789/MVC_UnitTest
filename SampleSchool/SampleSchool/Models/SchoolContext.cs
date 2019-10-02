using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SampleSchool.Models
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Enrolment> Enrolment { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=School;Trusted_Connection=True;");
            }
        }*/


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Enrolment>(entity =>
            {
                entity.HasKey(e => e.EnrolId);

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Sid).HasColumnName("SId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrolment)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseEnrol");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.Enrolment)
                    .HasForeignKey(d => d.Sid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StdEnrol");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.Sid);

                entity.Property(e => e.Sid).HasColumnName("SId");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });
        }
    }
}
