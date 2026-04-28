using LogisticsSystem.Application.DTOs;
using LogisticsSystem.Domain.Entities;

namespace LogisticsSystem.Application.Interfaces
{
    public interface ILoadService
    {
        Task<List<Load>> GetAllLoadsAsync();
        Task<Load?> GetLoadByIdAsync(int id);
        Task<Load> CreateLoadAsync(CreateLoadDto dto);
        Task<Load?> UpdateLoadAsync(int id, UpdateLoadDto dto);
        Task<bool> DeleteLoadAsync(int id);
    }
}