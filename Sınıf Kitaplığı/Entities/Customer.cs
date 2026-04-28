

namespace LogisticsSystem.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string? Address { get; set; }

        public User? User { get; set; }
    }
}