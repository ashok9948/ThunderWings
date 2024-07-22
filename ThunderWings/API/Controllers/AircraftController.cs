using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftRepository _aircraftRepository;

        public AircraftController(IAircraftRepository aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAircraft([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] AircraftFilter filter = null)
        {
            var aircraft = await _aircraftRepository.GetAircraftAsync(page, pageSize, filter ?? new AircraftFilter());
            return Ok(aircraft);
        }
    }
}