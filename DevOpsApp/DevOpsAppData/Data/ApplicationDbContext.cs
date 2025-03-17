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

        // Agregar DbSets para las tablas de la base de datos
        public DbSet<Projects> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projects>()
                .ToTable("projects")
                .HasKey(p => p.Index);

            modelBuilder.Entity<Projects>()
                .Property(p => p.Id)
                .HasMaxLength(36)
                .IsRequired();

            modelBuilder.Entity<Projects>()
                .Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Projects>()
                .Property(p => p.Description)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Projects>()
                .Property(p => p.Repository)
                .HasMaxLength(255);
        }
    }
}
