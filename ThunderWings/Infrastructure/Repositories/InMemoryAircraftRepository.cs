using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Infrastructure.Repositories
{
    public class InMemoryAircraftRepository : IAircraftRepository
    {
        private readonly List<Aircraft> _aircraft = new List<Aircraft>
        {
            new Aircraft { Id = 1, Name = "F-22 Raptor", Manufacturer = "Lockheed Martin", Country = "United States", Role = "Air Superiority Fighter", TopSpeed = 2414, Price = 150000000 },
            new Aircraft { Id = 2, Name = "Su-57", Manufacturer = "Sukhoi", Country = "Russia", Role = "Multirole Fighter", TopSpeed = 2440, Price = 100000000 },
            // Add more aircraft here
        };

        public async Task<IEnumerable<Aircraft>> GetAircraftAsync(int page, int pageSize, AircraftFilter filter)
        {
            var query = _aircraft.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(a => a.Name.Contains(filter.Name));

            if (!string.IsNullOrEmpty(filter.Manufacturer))
                query = query.Where(a => a.Manufacturer == filter.Manufacturer);

            if (!string.IsNullOrEmpty(filter.Country))
                query = query.Where(a => a.Country == filter.Country);

            if (!string.IsNullOrEmpty(filter.Role))
                query = query.Where(a => a.Role == filter.Role);

            if (filter.MinTopSpeed.HasValue)
                query = query.Where(a => a.TopSpeed >= filter.MinTopSpeed.Value);

            if (filter.MaxTopSpeed.HasValue)
                query = query.Where(a => a.TopSpeed <= filter.MaxTopSpeed.Value);

            if (filter.MinPrice.HasValue)
                query = query.Where(a => a.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(a => a.Price <= filter.MaxPrice.Value);

            return await Task.FromResult(query.Skip((page - 1) * pageSize).Take(pageSize).ToList());
        }

        public async Task<Aircraft> GetAircraftByIdAsync(int id)
        {
            return await Task.FromResult(_aircraft.FirstOrDefault(a => a.Id == id));
        }
    }
}