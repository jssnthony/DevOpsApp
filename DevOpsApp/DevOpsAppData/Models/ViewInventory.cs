using System;
using System.Collections.Generic;

namespace DevOpsAppData.Models;

public partial class ViewInventory
{
    public Guid UniqueKey { get; set; }

    public int Quantity { get; set; }

    public string CategoryName { get; set; } = null!;
}
