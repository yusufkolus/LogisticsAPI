using LogisticsSystem.Domain.Entities;

namespace LogisticsSystem.Domain.Interfaces
{
    public interface IDriverLoadRequestRepository
    {
        Task<List<DriverLoadRequest>> GetAllAsync();
        Task<DriverLoadRequest?> GetByIdAsync(int id);
        Task AddAsync(DriverLoadRequest request);
        Task UpdateAsync(DriverLoadRequest request);
    }
}
