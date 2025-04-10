using DevOpsAppData.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevOpsAppData.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Projects> Projects { get; set; }
        public DbSet<ProjectsTasks> ProjectsTasks { get; set; }

        public DbSet<ViewProjectsTasks> ViewProjectsTasks { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Projects>()
                .ToTable("projects")
                .HasKey(p => p.Index);

            modelBuilder.Entity<Projects>()
                .Property(p => p.Index)
                .HasColumnName("project_index")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Projects>()
                .Property(p => p.Id)
                .HasColumnName("project_id")
                .HasMaxLength(36)
                .IsRequired();

            modelBuilder.Entity<Projects>()
                .HasIndex(p => p.Id)
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

            // Configuración tabla projects_tasks
            modelBuilder.Entity<ProjectsTasks>()
                .ToTable("projects_tasks")
                .HasKey(t => t.Index);

            modelBuilder.Entity<ProjectsTasks>()
                .Property(t => t.Index)
                .HasColumnName("task_index")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProjectsTasks>()
                .Property(t => t.Id)
                .HasColumnName("task_id")
                .HasMaxLength(36)
                .IsRequired();

            modelBuilder.Entity<ProjectsTasks>()
                .HasIndex(t => t.Id)
                .IsUnique();

            modelBuilder.Entity<ProjectsTasks>()
                .Property(t => t.ProjectIndex)
                .HasColumnName("project_index")
                .IsRequired();

            modelBuilder.Entity<ProjectsTasks>()
                .Property(t => t.Title)
                .HasColumnName("task_title")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<ProjectsTasks>()
                .Property(t => t.Description)
                .HasColumnName("task_description")
                .HasColumnType("TEXT");

            modelBuilder.Entity<ProjectsTasks>()
                .Property(t => t.IsDone)
                .HasColumnName("is_done")
                .HasDefaultValue(false);

            modelBuilder.Entity<ProjectsTasks>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectIndex)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ViewProjectsTasks>()
            .ToTable("view_projects_tasks")  // Asegúrate que el nombre de la vista sea correcto
            .HasNoKey()  // Indica que no tiene una clave primaria explícita
            .Property(p => p.TaskId)  // Definir la propiedad Id sin clave primaria
            .ValueGeneratedNever();  // Asegura que no se generen valores automáticamente para Id
        }
    }
}
