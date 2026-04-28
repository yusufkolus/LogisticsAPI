using LogisticsSystem.Application.DTOs;
using LogisticsSystem.Application.Interfaces;
using LogisticsSystem.Domain.Entities;
using LogisticsSystem.Domain.Interfaces;

namespace LogisticsSystem.Application.Services
{
    public class LoadService : ILoadService
    {
        private readonly ILoadRepository _loadRepository;

        public LoadService(ILoadRepository loadRepository)
        {
            _loadRepository = loadRepository;
        }

        public async Task<List<Load>> GetAllLoadsAsync()
        {
            return await _loadRepository.GetAllAsync();
        }

        public async Task<Load?> GetLoadByIdAsync(int id)
        {
            return await _loadRepository.GetByIdAsync(id);
        }

        public async Task<Load> CreateLoadAsync(CreateLoadDto dto)
        {
            // İş kuralı validasyonları
            if (dto.SourceWarehouseId == dto.TargetWarehouseId)
                throw new ArgumentException("Kaynak ve hedef depo farklı olmalıdır.");

            if (dto.CreatedDate > DateTime.Now)
                throw new ArgumentException("Oluşturma tarihi gelecekte olamaz.");

            var load = new Load
            {
                LoadName = dto.LoadName,
                LoadTypeId = dto.LoadTypeId,
                Description = dto.Description,
                Weight = dto.Weight,
                Quantity = dto.Quantity,
                SourceWarehouseId = dto.SourceWarehouseId,
                TargetWarehouseId = dto.TargetWarehouseId,
                CustomerId = dto.CustomerId,
                CreatedDate = dto.CreatedDate,
                Status = dto.Status,
                CreatedByAdminId = dto.CreatedByAdminId
            };

            await _loadRepository.AddAsync(load);
            return load;
        }

        public async Task<Load?> UpdateLoadAsync(int id, UpdateLoadDto dto)
        {
            var load = await _loadRepository.GetByIdAsync(id);

            if (load == null)
                return null;

            // İş kuralı validasyonları
            if (dto.SourceWarehouseId == dto.TargetWarehouseId)
                throw new ArgumentException("Kaynak ve hedef depo farklı olmalıdır.");

            if (dto.CreatedDate > DateTime.Now)
                throw new ArgumentException("Oluşturma tarihi gelecekte olamaz.");

            load.LoadName = dto.LoadName;
            load.LoadTypeId = dto.LoadTypeId;
            load.Description = dto.Description;
            load.Weight = dto.Weight;
            load.Quantity = dto.Quantity;
            load.SourceWarehouseId = dto.SourceWarehouseId;
            load.TargetWarehouseId = dto.TargetWarehouseId;
            load.CustomerId = dto.CustomerId;
            load.CreatedDate = dto.CreatedDate;
            load.Status = dto.Status;
            load.CreatedByAdminId = dto.CreatedByAdminId;

            await _loadRepository.UpdateAsync(load);
            return load;
        }

        public async Task<bool> DeleteLoadAsync(int id)
        {
            var load = await _loadRepository.GetByIdAsync(id);

            if (load == null)
                return false;

            await _loadRepository.DeleteAsync(load);
            return true;
        }
    }
}