using System;
using System.Collections.Generic;

namespace Project_PRN231_API.Models
{
    public partial class PlantProcess
    {
        public int PlantProcessId { get; set; }
        public int? CropId { get; set; }
        public int? UserId { get; set; }
        public DateTime PlantingDate { get; set; }
        public DateTime? ExpectedHarvestDate { get; set; }
        public decimal Quantity { get; set; }

        public virtual Crop? Crop { get; set; }
        public virtual User? User { get; set; }
    }
}
