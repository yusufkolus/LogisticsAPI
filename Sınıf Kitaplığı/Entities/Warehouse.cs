namespace LogisticsSystem.Domain.Entities
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;
        public bool IsActive { get; set; }

        public ICollection<Driver> Drivers { get; set; } = new List<Driver>();
    }
}