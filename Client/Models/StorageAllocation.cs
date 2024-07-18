using System;
using System.Collections.Generic;

namespace Project_PRN231_Client.Models
{
    public partial class StorageAllocation
    {
        public int StorageAllocationId { get; set; }
        public int? HarvestProcessId { get; set; }
        public int? StorageId { get; set; }
        public decimal Quantity { get; set; }

        public virtual HarvestProcess? HarvestProcess { get; set; }
        public virtual Storage? Storage { get; set; }
    }
}
