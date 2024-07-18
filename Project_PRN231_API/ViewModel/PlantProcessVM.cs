namespace Project_PRN231_API.ViewModel
{
    public class PlantProcessVM
    {
        public int PlantProcessId { get; set; }
        public int? CropId { get; set; }
        public int? UserId { get; set; }
        public DateTime PlantingDate { get; set; }
        public DateTime? ExpectedHarvestDate { get; set; }
        public decimal Quantity { get; set; }
    }
}
