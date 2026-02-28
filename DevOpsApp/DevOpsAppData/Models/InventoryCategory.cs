using System;
using System.Collections.Generic;

namespace DevOpsAppData.Models;

public partial class InventoryCategory
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
