using LogisticsSystem.Application.DTOs;
using LogisticsSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadsController : ControllerBase
    {
        private readonly ILoadService _loadService;

        public LoadsController(ILoadService loadService)
        {
            _loadService = loadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoads()
        {
            var loads = await _loadService.GetAllLoadsAsync();
            return Ok(loads);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoadById(int id)
        {
            var load = await _loadService.GetLoadByIdAsync(id);

            if (load == null)
                return NotFound("Yük bulunamadı.");

            return Ok(load);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoad([FromBody] CreateLoadDto dto)
        {
            try
            {
                var createdLoad = await _loadService.CreateLoadAsync(dto);
                return Ok(createdLoad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoad(int id, [FromBody] UpdateLoadDto dto)
        {
            try
            {
                var updatedLoad = await _loadService.UpdateLoadAsync(id, dto);

                if (updatedLoad == null)
                    return NotFound("Güncellenecek yük bulunamadı.");

                return Ok(updatedLoad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoad(int id)
        {
            var result = await _loadService.DeleteLoadAsync(id);

            if (!result)
                return NotFound("Silinecek yük bulunamadı.");

            return Ok("Yük başarıyla silindi.");
        }
    }
}