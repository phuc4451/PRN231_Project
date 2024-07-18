using System;
using System.Collections.Generic;

namespace Project_PRN231_Client.Models
{
    public partial class Storage
    {
        public Storage()
        {
            SaleProcesses = new HashSet<SaleProcess>();
            StorageAllocations = new HashSet<StorageAllocation>();
        }

        public int StorageId { get; set; }
        public string StorageName { get; set; } = null!;
        public decimal Capacity { get; set; }

        public virtual ICollection<SaleProcess> SaleProcesses { get; set; }
        public virtual ICollection<StorageAllocation> StorageAllocations { get; set; }
    }
}
