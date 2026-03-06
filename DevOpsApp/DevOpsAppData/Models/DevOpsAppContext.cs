using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

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

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<InventoryCategory> InventoryCategories { get; set; }

    public virtual DbSet<Label> Labels { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectsTask> ProjectsTasks { get; set; }

    public virtual DbSet<ViewInventory> ViewInventories { get; set; }

    public virtual DbSet<ViewTasksProject> ViewTasksProjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=devopsapp;user=jss;password=n0m3l0s3;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.6.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inventory");

            entity.HasIndex(e => e.CategoryId, "CATEGORY_ID");

            entity.HasIndex(e => e.UniqueKey, "UNIQUE_KEY").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            entity.Property(e => e.UniqueKey).HasColumnName("UNIQUE_KEY");

            entity.HasOne(d => d.Category).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("inventory_ibfk_1");
        });

        modelBuilder.Entity<InventoryCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("inventory_category");

            entity.HasIndex(e => e.CategoryName, "CATEGORY_NAME").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("CATEGORY_NAME");
        });

        modelBuilder.Entity<Label>(entity =>
        {
            entity.HasKey(e => e.LabelIndex).HasName("PRIMARY");

            entity.ToTable("labels");

            entity.HasIndex(e => e.LabelName, "LABEL_NAME").IsUnique();

            entity.Property(e => e.LabelIndex).HasColumnName("LABEL_INDEX");
            entity.Property(e => e.LabelColor)
                .HasMaxLength(7)
                .HasDefaultValueSql("'#FFFFFF'")
                .HasColumnName("LABEL_COLOR");
            entity.Property(e => e.LabelDescription)
                .HasColumnType("text")
                .HasColumnName("LABEL_DESCRIPTION");
            entity.Property(e => e.LabelIcon)
                .HasMaxLength(100)
                .HasDefaultValueSql("'TAG'")
                .HasColumnName("LABEL_ICON");
            entity.Property(e => e.LabelIsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("LABEL_IS_ACTIVE");
            entity.Property(e => e.LabelName)
                .HasMaxLength(100)
                .HasColumnName("LABEL_NAME");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectIndex).HasName("PRIMARY");

            entity.ToTable("projects");

            entity.HasIndex(e => e.ProjectId, "PROJECT_ID").IsUnique();

            entity.Property(e => e.ProjectIndex).HasColumnName("PROJECT_INDEX");
            entity.Property(e => e.ProjectCreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("PROJECT_CREATED_AT");
            entity.Property(e => e.ProjectCreatedBy)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYS'")
                .HasColumnName("PROJECT_CREATED_BY");
            entity.Property(e => e.ProjectDescription)
                .HasColumnType("text")
                .HasColumnName("PROJECT_DESCRIPTION");
            entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");
            entity.Property(e => e.ProjectIsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("PROJECT_IS_ACTIVE");
            entity.Property(e => e.ProjectIsArchive).HasColumnName("PROJECT_IS_ARCHIVE");
            entity.Property(e => e.ProjectLabels)
                .HasColumnType("text")
                .HasColumnName("PROJECT_LABELS");
            entity.Property(e => e.ProjectNotes)
                .HasColumnType("text")
                .HasColumnName("PROJECT_NOTES");
            entity.Property(e => e.ProjectPriority).HasColumnName("PROJECT_PRIORITY");
            entity.Property(e => e.ProjectRepository)
                .HasMaxLength(255)
                .HasColumnName("PROJECT_REPOSITORY");
            entity.Property(e => e.ProjectTitle)
                .HasMaxLength(255)
                .HasColumnName("PROJECT_TITLE");
            entity.Property(e => e.ProjectUpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("PROJECT_UPDATED_AT");
            entity.Property(e => e.ProjectUpdatedBy)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYS'")
                .HasColumnName("PROJECT_UPDATED_BY");
        });

        modelBuilder.Entity<ProjectsTask>(entity =>
        {
            entity.HasKey(e => e.TaskIndex).HasName("PRIMARY");

            entity.ToTable("projects_tasks");

            entity.HasIndex(e => e.ProjectIndex, "FK_PROJECTS_TASKS_PROJECTS");

            entity.HasIndex(e => e.TaskId, "TASK_ID").IsUnique();

            entity.Property(e => e.TaskIndex).HasColumnName("TASK_INDEX");
            entity.Property(e => e.ProjectIndex).HasColumnName("PROJECT_INDEX");
            entity.Property(e => e.TaskCreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("TASK_CREATED_AT");
            entity.Property(e => e.TaskCreatedBy)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYS'")
                .HasColumnName("TASK_CREATED_BY");
            entity.Property(e => e.TaskDescription)
                .HasColumnType("text")
                .HasColumnName("TASK_DESCRIPTION");
            entity.Property(e => e.TaskId).HasColumnName("TASK_ID");
            entity.Property(e => e.TaskLabels)
                .HasColumnType("text")
                .HasColumnName("TASK_LABELS");
            entity.Property(e => e.TaskPriority).HasColumnName("TASK_PRIORITY");
            entity.Property(e => e.TaskProgressStatus)
                .HasDefaultValueSql("'1'")
                .HasColumnName("TASK_PROGRESS_STATUS");
            entity.Property(e => e.TaskTitle)
                .HasMaxLength(255)
                .HasColumnName("TASK_TITLE");
            entity.Property(e => e.TaskUpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("TASK_UPDATED_AT");
            entity.Property(e => e.TaskUpdatedBy)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYS'")
                .HasColumnName("TASK_UPDATED_BY");

            entity.HasOne(d => d.ProjectIndexNavigation).WithMany(p => p.ProjectsTasks)
                .HasForeignKey(d => d.ProjectIndex)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PROJECTS_TASKS_PROJECTS");
        });

        modelBuilder.Entity<ViewInventory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_inventory");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("CATEGORY_NAME");
            entity.Property(e => e.Quantity).HasColumnName("QUANTITY");
            entity.Property(e => e.UniqueKey).HasColumnName("UNIQUE_KEY");
        });

        modelBuilder.Entity<ViewTasksProject>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_tasks_projects");

            entity.Property(e => e.ProjectCreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("PROJECT_CREATED_AT");
            entity.Property(e => e.ProjectCreatedBy)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYS'")
                .HasColumnName("PROJECT_CREATED_BY");
            entity.Property(e => e.ProjectDescription)
                .HasColumnType("text")
                .HasColumnName("PROJECT_DESCRIPTION");
            entity.Property(e => e.ProjectId).HasColumnName("PROJECT_ID");
            entity.Property(e => e.ProjectIndex).HasColumnName("PROJECT_INDEX");
            entity.Property(e => e.ProjectIsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("PROJECT_IS_ACTIVE");
            entity.Property(e => e.ProjectIsArchive).HasColumnName("PROJECT_IS_ARCHIVE");
            entity.Property(e => e.ProjectLabels)
                .HasColumnType("text")
                .HasColumnName("PROJECT_LABELS");
            entity.Property(e => e.ProjectNotes)
                .HasColumnType("text")
                .HasColumnName("PROJECT_NOTES");
            entity.Property(e => e.ProjectPriority).HasColumnName("PROJECT_PRIORITY");
            entity.Property(e => e.ProjectRepository)
                .HasMaxLength(255)
                .HasColumnName("PROJECT_REPOSITORY");
            entity.Property(e => e.ProjectTitle)
                .HasMaxLength(255)
                .HasColumnName("PROJECT_TITLE");
            entity.Property(e => e.ProjectUpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("PROJECT_UPDATED_AT");
            entity.Property(e => e.ProjectUpdatedBy)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYS'")
                .HasColumnName("PROJECT_UPDATED_BY");
            entity.Property(e => e.TaskCreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("TASK_CREATED_AT");
            entity.Property(e => e.TaskCreatedBy)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYS'")
                .HasColumnName("TASK_CREATED_BY");
            entity.Property(e => e.TaskDescription)
                .HasColumnType("text")
                .HasColumnName("TASK_DESCRIPTION");
            entity.Property(e => e.TaskId).HasColumnName("TASK_ID");
            entity.Property(e => e.TaskIndex).HasColumnName("TASK_INDEX");
            entity.Property(e => e.TaskLabels)
                .HasColumnType("text")
                .HasColumnName("TASK_LABELS");
            entity.Property(e => e.TaskPriority).HasColumnName("TASK_PRIORITY");
            entity.Property(e => e.TaskProgressStatus)
                .HasDefaultValueSql("'1'")
                .HasColumnName("TASK_PROGRESS_STATUS");
            entity.Property(e => e.TaskTitle)
                .HasMaxLength(255)
                .HasColumnName("TASK_TITLE");
            entity.Property(e => e.TaskUpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("TASK_UPDATED_AT");
            entity.Property(e => e.TaskUpdatedBy)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYS'")
                .HasColumnName("TASK_UPDATED_BY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
