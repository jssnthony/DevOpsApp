using System;
using System.Collections.Generic;

namespace DevOpsAppData.Models;

public partial class ViewTasksProject
{
    public int TaskIndex { get; set; }

    public Guid TaskId { get; set; }

    public string TaskTitle { get; set; } = null!;

    public string TaskDescription { get; set; } = null!;

    public int TaskProgressStatus { get; set; }

    public int TaskPriority { get; set; }

    public string? TaskLabels { get; set; }

    public DateTime TaskCreatedAt { get; set; }

    public DateTime TaskUpdatedAt { get; set; }

    public string TaskCreatedBy { get; set; } = null!;

    public string TaskUpdatedBy { get; set; } = null!;

    public int ProjectIndex { get; set; }

    public Guid ProjectId { get; set; }

    public string ProjectTitle { get; set; } = null!;

    public string ProjectDescription { get; set; } = null!;

    public string ProjectRepository { get; set; } = null!;

    public bool ProjectIsArchive { get; set; }

    public bool? ProjectIsActive { get; set; }

    public int ProjectPriority { get; set; }

    public string? ProjectNotes { get; set; }

    public string? ProjectLabels { get; set; }

    public DateTime ProjectCreatedAt { get; set; }

    public DateTime ProjectUpdatedAt { get; set; }

    public string ProjectCreatedBy { get; set; } = null!;

    public string ProjectUpdatedBy { get; set; } = null!;
}
