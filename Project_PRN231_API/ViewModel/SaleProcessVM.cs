namespace Project_PRN231_API.ViewModel
{
    public class SaleProcessVM
    {
        public int SaleProcessId { get; set; }
        public int? StorageId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Quantity { get; set; }
        public string? Destination { get; set; }
    }
}
