using Microsoft.EntityFrameworkCore;

namespace DevOpsAppData.Models;

public partial class DevOpsAppContext : DbContext
{
    public DevOpsAppContext()
    {
    }

    public DevOpsAppContext(DbContextOptions<DevOpsAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectsTask> ProjectsTasks { get; set; }

    public virtual DbSet<ViewProjectsTask> ViewProjectsTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectIndex).HasName("PRIMARY");

            entity.ToTable("projects");

            entity.HasIndex(e => e.ProjectId, "project_id").IsUnique();

            entity.Property(e => e.ProjectIndex).HasColumnName("project_index");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsArchive).HasColumnName("is_archive");
            entity.Property(e => e.ProjectDescription)
                .HasColumnType("text")
                .HasColumnName("project_description");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ProjectRepository)
                .HasMaxLength(255)
                .HasColumnName("project_repository");
            entity.Property(e => e.ProjectTitle)
                .HasMaxLength(255)
                .HasColumnName("project_title");
        });

        modelBuilder.Entity<ProjectsTask>(entity =>
        {
            entity.HasKey(e => e.TaskIndex).HasName("PRIMARY");

            entity.ToTable("projects_tasks");

            entity.HasIndex(e => e.ProjectIndex, "project_index");

            entity.HasIndex(e => e.TaskId, "task_id").IsUnique();

            entity.Property(e => e.TaskIndex).HasColumnName("task_index");
            entity.Property(e => e.IsDone).HasColumnName("is_done");
            entity.Property(e => e.ProjectIndex).HasColumnName("project_index");
            entity.Property(e => e.TaskDescription)
                .HasColumnType("text")
                .HasColumnName("task_description");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.TaskTitle)
                .HasMaxLength(255)
                .HasColumnName("task_title");

            entity.HasOne(d => d.ProjectIndexNavigation).WithMany(p => p.ProjectsTasks)
                .HasForeignKey(d => d.ProjectIndex)
                .HasConstraintName("projects_tasks_ibfk_1");
        });

        modelBuilder.Entity<ViewProjectsTask>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_projects_tasks");

            entity.Property(e => e.IsDone).HasColumnName("is_done");
            entity.Property(e => e.ProjectDescription)
                .HasColumnType("text")
                .HasColumnName("project_description");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ProjectRepository)
                .HasMaxLength(255)
                .HasColumnName("project_repository");
            entity.Property(e => e.ProjectTitle)
                .HasMaxLength(255)
                .HasColumnName("project_title");
            entity.Property(e => e.TaskDescription)
                .HasColumnType("text")
                .HasColumnName("task_description");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.TaskTitle)
                .HasMaxLength(255)
                .HasColumnName("task_title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
