namespace LogisticsSystem.Application.DTOs
{
    public class CreateLoadDto
    {
        public string LoadName { get; set; } = null!;
        public int LoadTypeId { get; set; }
        public string? Description { get; set; }
        public decimal Weight { get; set; }
        public int Quantity { get; set; }
        public int SourceWarehouseId { get; set; }
        public int TargetWarehouseId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } = null!;
        public int CreatedByAdminId { get; set; }
    }
}