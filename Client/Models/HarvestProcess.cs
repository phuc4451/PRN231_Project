using System;
using System.Collections.Generic;

namespace Project_PRN231_Client.Models
{
    public partial class HarvestProcess
    {
        public HarvestProcess()
        {
            StorageAllocations = new HashSet<StorageAllocation>();
        }

        public int HarvestProcessId { get; set; }
        public int? CropId { get; set; }
        public DateTime HarvestDate { get; set; }
        public decimal QuantityHarvested { get; set; }
        public int? UserId { get; set; }

        public virtual Crop? Crop { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<StorageAllocation> StorageAllocations { get; set; }
    }
}
