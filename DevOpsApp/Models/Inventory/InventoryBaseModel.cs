using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Inventory
{
    public class InventoryBaseModel
    {
        public int KeyId { get; set; }
        public Guid InventoryId { get; set; }
        public EnumInventoryCategory InventoryCategory { get; set; }
        public string InventoryCategoryDetails { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
