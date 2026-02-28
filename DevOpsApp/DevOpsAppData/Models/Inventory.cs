using System;
using System.Collections.Generic;

namespace DevOpsAppData.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public Guid UniqueKey { get; set; }

    public int Quantity { get; set; }

    public int? CategoryId { get; set; }

    public virtual InventoryCategory? Category { get; set; }
}
