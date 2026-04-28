using LogisticsSystem.Domain.Entities;
using LogisticsSystem.Domain.Interfaces;
using LogisticsSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LogisticsSystem.Infrastructure.Repositories
{
    public class DriverLoadRequestRepository : IDriverLoadRequestRepository
    {
        private readonly AppDbContext _context;

        public DriverLoadRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DriverLoadRequest>> GetAllAsync()
        {
            return await _context.DriverLoadRequests.ToListAsync();
        }

        public async Task<DriverLoadRequest?> GetByIdAsync(int id)
        {
            return await _context.DriverLoadRequests.FindAsync(id);
        }

        public async Task AddAsync(DriverLoadRequest request)
        {
            await _context.DriverLoadRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DriverLoadRequest request)
        {
            _context.DriverLoadRequests.Update(request);
            await _context.SaveChangesAsync();
        }
    }
}