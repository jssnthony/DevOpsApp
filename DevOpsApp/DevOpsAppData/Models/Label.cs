using System;
using System.Collections.Generic;

namespace DevOpsAppData.Models;

public partial class Label
{
    public int LabelIndex { get; set; }

    public string LabelName { get; set; } = null!;

    public string? LabelDescription { get; set; }

    public string LabelColor { get; set; } = null!;

    public string LabelIcon { get; set; } = null!;

    public bool? LabelIsActive { get; set; }
}
