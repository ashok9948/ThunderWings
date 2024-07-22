using Microsoft.AspNetCore.Mvc;
using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.API.Controllers
{
    // Attribute to specify that this class is an API controller
    [ApiController]
    // Route attribute to define the base route for all actions in this controller
    [Route("api/[controller]")]
    public class AircraftController : ControllerBase
    {
        // Private readonly field to hold the reference to the aircraft repository
        private readonly IAircraftRepository _aircraftRepository;

        // Constructor to initialize the aircraft repository via dependency injection
        public AircraftController(IAircraftRepository aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }

        // HTTP GET method to retrieve a list of aircraft with pagination and optional filtering
        [HttpGet]
        public async Task<IActionResult> GetAircraft(
            // Parameters to specify the page number, page size, and filter criteria for the query
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] AircraftFilter filter = null)
        {
            // Retrieve aircraft data from the repository with the given parameters
            var aircraft = await _aircraftRepository.GetAircraftAsync(page, pageSize, filter ?? new AircraftFilter());
            // Return the retrieved aircraft data with an OK (200) response
            return Ok(aircraft);
        }
    }
}