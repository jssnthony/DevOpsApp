using DevOpsAppData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppData.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Projects> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projects>()
                .ToTable("projects")
                .HasKey(p => p.Index); // Clave primaria en project_index

            modelBuilder.Entity<Projects>()
                .Property(p => p.Index)
                .HasColumnName("project_index")
                .ValueGeneratedOnAdd(); // Auto incremento

            modelBuilder.Entity<Projects>()
                .Property(p => p.Id)
                .HasColumnName("project_id")
                .HasMaxLength(36)
                .IsRequired();

            modelBuilder.Entity<Projects>()
                .HasIndex(p => p.Id) // Asegura unicidad en project_id
                .IsUnique();

            modelBuilder.Entity<Projects>()
                .Property(p => p.Title)
                .HasColumnName("project_title")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Projects>()
                .Property(p => p.Description)
                .HasColumnName("project_description")
                .HasColumnType("TEXT");

            modelBuilder.Entity<Projects>()
                .Property(p => p.Repository)
                .HasColumnName("project_repository")
                .HasMaxLength(255);

            modelBuilder.Entity<Projects>()
                .Property(p => p.IsArchive)
                .HasColumnName("is_archive")
                .HasDefaultValue(0);

            modelBuilder.Entity<Projects>()
                .Property(p => p.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(0);
        }
    }
}
