namespace LogisticsSystem.Domain.Entities
{
    public class DriverLoadRequest
    {
        public int Id { get; set; }

        public int DriverId { get; set; }

        public int LoadId { get; set; }

        public DateTime RequestDate { get; set; }

        public string RequestStatus { get; set; } = null!;

        public string? AdminNote { get; set; }
    }
}
