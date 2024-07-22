using System.Collections.Generic;
using System.Threading.Tasks;
using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Application.Services
{
    public class AircraftService
    {
        private readonly IAircraftRepository _aircraftRepository;

        public AircraftService(IAircraftRepository aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }

        public async Task<IEnumerable<Aircraft>> GetAircraftAsync(int page, int pageSize, AircraftFilter filter)
        {
            return await _aircraftRepository.GetAircraftAsync(page, pageSize, filter);
        }
    }
}