using LogisticsSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverLoadRequestsController : ControllerBase
    {
        private readonly IDriverLoadRequestService _service;

        public DriverLoadRequestsController(IDriverLoadRequestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _service.GetAllAsync();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _service.GetByIdAsync(id);

            if (request == null)
                return NotFound("Talep bulunamadı.");

            return Ok(request);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(int driverId, int loadId)
        {
            var request = await _service.CreateRequestAsync(driverId, loadId);
            return Ok(request);
        }

        [HttpPut("{id}/approve")]
        public async Task<IActionResult> ApproveRequest(int id, string? adminNote)
        {
            var result = await _service.ApproveRequestAsync(id, adminNote);

            if (!result)
                return NotFound("Onaylanacak talep bulunamadı.");

            return Ok("Talep onaylandı.");
        }

        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectRequest(int id, string? adminNote)
        {
            var result = await _service.RejectRequestAsync(id, adminNote);

            if (!result)
                return NotFound("Reddedilecek talep bulunamadı.");

            return Ok("Talep reddedildi.");
        }
    }
}