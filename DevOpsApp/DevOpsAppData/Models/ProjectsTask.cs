using System;
using System.Collections.Generic;

namespace DevOpsAppData.Models;

public partial class ProjectsTask
{
    public int TaskIndex { get; set; }

    public Guid TaskId { get; set; }

    public int ProjectIndex { get; set; }

    public string TaskTitle { get; set; } = null!;

    public string TaskDescription { get; set; } = null!;

    public int TaskProgressStatus { get; set; }

    public int TaskPriority { get; set; }

    public string? TaskLabels { get; set; }

    public DateTime TaskCreatedAt { get; set; }

    public DateTime TaskUpdatedAt { get; set; }

    public string TaskCreatedBy { get; set; } = null!;

    public string TaskUpdatedBy { get; set; } = null!;

    public virtual Project ProjectIndexNavigation { get; set; } = null!;
}
