using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLibrary.Entities
{
    public partial class InterviewContext : DbContext
    {
        public InterviewContext()
        {
        }

        public InterviewContext(DbContextOptions<InterviewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
