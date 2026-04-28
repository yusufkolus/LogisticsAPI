using LogisticsSystem.Domain.Entities;

namespace LogisticsSystem.Domain.Interfaces
{
    public interface ILoadRepository
    {
        Task<List<Load>> GetAllAsync();
        Task<Load?> GetByIdAsync(int id);
        Task AddAsync(Load load);
        Task UpdateAsync(Load load);
        Task DeleteAsync(Load load);

        Task<List<Load>> GetLoadsByDriverWarehouseAsync(int driverId);
    }
}