using System.Collections.Generic; 
using System.Threading.Tasks; 
using ThunderWings.Application.Interfaces; 
using ThunderWings.Domain.Entities; 

namespace ThunderWings.Application.Services
{
    /// <summary>
    /// Service class for managing aircraft-related operations.
    /// </summary>
    public class AircraftService
    {
        private readonly IAircraftRepository _aircraftRepository; // Repository interface for accessing aircraft data

        /// <summary>
        /// Constructor that initializes the AircraftService with the specified repository.
        /// </summary>
        /// <param name="aircraftRepository">The repository for aircraft data.</param>
        public AircraftService(IAircraftRepository aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }

        /// <summary>
        /// Asynchronously retrieves a paginated list of aircraft based on the specified filter.
        /// </summary>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="pageSize">The number of aircraft per page.</param>
        /// <param name="filter">The filter criteria for the aircraft.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of aircraft.</returns>
        public async Task<IEnumerable<Aircraft>> GetAircraftAsync(int page, int pageSize, AircraftFilter filter)
        {
            return await _aircraftRepository.GetAircraftAsync(page, pageSize, filter); // Delegates the call to the repository
        }
    }
}
