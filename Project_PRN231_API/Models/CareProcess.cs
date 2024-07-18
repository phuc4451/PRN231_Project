using System;
using System.Collections.Generic;

namespace Project_PRN231_API.Models
{
    public partial class CareProcess
    {
        public int CareProcessId { get; set; }
        public int? CropId { get; set; }
        public int? UserId { get; set; }
        public string TaskDescription { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public string CompletionStatus { get; set; } = null!;
        public DateTime? CompletionDate { get; set; }
        public string? MaterialsUsed { get; set; }

        public virtual Crop? Crop { get; set; }
        public virtual User? User { get; set; }
    }
}
