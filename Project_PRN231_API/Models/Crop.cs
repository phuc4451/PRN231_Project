using System;
using System.Collections.Generic;

namespace Project_PRN231_API.Models
{
    public partial class Crop
    {
        public Crop()
        {
            CareProcesses = new HashSet<CareProcess>();
            HarvestProcesses = new HashSet<HarvestProcess>();
            PlantProcesses = new HashSet<PlantProcess>();
        }

        public int CropId { get; set; }
        public string CropName { get; set; } = null!;
        public string CropType { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual ICollection<CareProcess> CareProcesses { get; set; }
        public virtual ICollection<HarvestProcess> HarvestProcesses { get; set; }
        public virtual ICollection<PlantProcess> PlantProcesses { get; set; }
    }
}
