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
            return Ok(new { success = true, data = loads, count = loads.Count });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoadById(int id)
        {
            var load = await _loadService.GetLoadByIdAsync(id);

            if (load == null)
                return NotFound(new { success = false, message = "Yük bulunamadı." });

            return Ok(new { success = true, data = load });
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoad([FromBody] CreateLoadDto dto)
        {
            // Model validation kontrol
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
                return BadRequest(new { success = false, errors = errors });
            }

            try
            {
                var createdLoad = await _loadService.CreateLoadAsync(dto);
                return CreatedAtAction(nameof(GetLoadById), new { id = createdLoad.LoadId }, 
                    new { success = true, data = createdLoad });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Veritabanı hatası", detail = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoad(int id, [FromBody] UpdateLoadDto dto)
        {
            // Model validation kontrol
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
                return BadRequest(new { success = false, errors = errors });
            }

            try
            {
                var updatedLoad = await _loadService.UpdateLoadAsync(id, dto);

                if (updatedLoad == null)
                    return NotFound(new { success = false, message = "Güncellenecek yük bulunamadı." });

                return Ok(new { success = true, data = updatedLoad });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Veritabanı hatası", detail = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoad(int id)
        {
            var result = await _loadService.DeleteLoadAsync(id);

            if (!result)
                return NotFound(new { success = false, message = "Silinecek yük bulunamadı." });

            return Ok(new { success = true, message = "Yük başarıyla silindi." });
        }
    }
}