namespace Project_PRN231_API.ViewModel
{
    public class HarvestProcessVM
    {
        public int HarvestProcessId { get; set; }
        public int? CropId { get; set; }
        public DateTime HarvestDate { get; set; }
        public decimal QuantityHarvested { get; set; }
        public int? UserId { get; set; }
    }
}
