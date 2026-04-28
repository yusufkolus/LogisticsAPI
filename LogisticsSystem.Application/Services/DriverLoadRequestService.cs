using LogisticsSystem.Application.Interfaces;
using LogisticsSystem.Domain.Entities;
using LogisticsSystem.Domain.Interfaces;

namespace LogisticsSystem.Application.Services
{
    public class DriverLoadRequestService : IDriverLoadRequestService
    {
        private readonly IDriverLoadRequestRepository _repository;
        private readonly ILoadRepository _loadRepository;

        public DriverLoadRequestService(
            IDriverLoadRequestRepository repository,
            ILoadRepository loadRepository)
        {
            _repository = repository;
            _loadRepository = loadRepository;
        }

        public async Task<List<DriverLoadRequest>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<DriverLoadRequest?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<DriverLoadRequest> CreateRequestAsync(int driverId, int loadId)
        {
            var request = new DriverLoadRequest
            {
                DriverId = driverId,
                LoadId = loadId,
                RequestDate = DateTime.Now,
                RequestStatus = "Beklemede"
            };

            await _repository.AddAsync(request);
            return request;
        }

        public async Task<bool> ApproveRequestAsync(int requestId, string? adminNote)
        {
            var request = await _repository.GetByIdAsync(requestId);

            if (request == null)
                return false;

            var load = await _loadRepository.GetByIdAsync(request.LoadId);

            if (load == null)
                return false;

            request.RequestStatus = "Onaylandı";
            request.AdminNote = adminNote;

            load.DriverId = request.DriverId;
            load.Status = "Şoföre Atandı";

            await _loadRepository.UpdateAsync(load);
            await _repository.UpdateAsync(request);

            return true;
        }

        public async Task<bool> RejectRequestAsync(int requestId, string? adminNote)
        {
            var request = await _repository.GetByIdAsync(requestId);

            if (request == null)
                return false;

            request.RequestStatus = "Reddedildi";
            request.AdminNote = adminNote;

            await _repository.UpdateAsync(request);
            return true;
        }
    }
}