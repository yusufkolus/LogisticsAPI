using LogisticsSystem.Domain.Entities;

namespace LogisticsSystem.Application.Interfaces
{
    public interface IDriverLoadRequestService
    {
        Task<List<DriverLoadRequest>> GetAllAsync();
        Task<DriverLoadRequest?> GetByIdAsync(int id);

        Task<DriverLoadRequest> CreateRequestAsync(int driverId, int loadId);

        Task<bool> ApproveRequestAsync(int requestId, string? adminNote);
        Task<bool> RejectRequestAsync(int requestId, string? adminNote);
    }
}