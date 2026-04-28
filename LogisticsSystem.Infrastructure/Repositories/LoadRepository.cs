using LogisticsSystem.Domain.Entities;
using LogisticsSystem.Domain.Interfaces;
using LogisticsSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LogisticsSystem.Infrastructure.Repositories
{
    public class LoadRepository : ILoadRepository
    {
        private readonly AppDbContext _context;

        public LoadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Load>> GetAllAsync()
        {
            return await _context.Loads.ToListAsync();
        }

        public async Task<Load?> GetByIdAsync(int id)
        {
            return await _context.Loads.FindAsync(id);
        }

        public async Task AddAsync(Load load)
        {
            await _context.Loads.AddAsync(load);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Load load)
        {
            _context.Loads.Update(load);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Load load)
        {
            _context.Loads.Remove(load);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Load>> GetLoadsByDriverWarehouseAsync(int driverId)
        {
            var driver = await _context.Drivers
                .FirstOrDefaultAsync(d => d.DriverId == driverId);

            if (driver == null)
                return new List<Load>();

            return await _context.Loads
                .Where(l => l.SourceWarehouseId == driver.WarehouseId)
                .Where(l => l.DriverId == null)
                .ToListAsync();
        }
    }
}