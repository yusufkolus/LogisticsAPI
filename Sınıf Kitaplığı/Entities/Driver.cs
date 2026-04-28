namespace LogisticsSystem.Domain.Entities
{
    public class Driver
    {
        public int DriverId { get; set; }
        public int UserId { get; set; }
        public int WarehouseId { get; set; }  //şöförün bağlı olduğu depo ıdsi

        public string DriverNumber { get; set; } = null!;
        public string CurrentCity { get; set; } = null!;
        public string AvailabilityStatus { get; set; } = null!;

        public User? User { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}