using System;
using System.Collections.Generic;

namespace Project_PRN231_API.Models
{
    public partial class SaleProcess
    {
        public int SaleProcessId { get; set; }
        public int? StorageId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Quantity { get; set; }
        public string? Destination { get; set; }

        public virtual Storage? Storage { get; set; }
    }
}
