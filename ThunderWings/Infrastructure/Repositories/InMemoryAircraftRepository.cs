using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Infrastructure.Repositories
{
    // InMemoryAircraftRepository is a repository implementation for accessing aircraft data.
    // It stores the aircraft data in memory and provides methods to query and retrieve aircraft information.
    public class InMemoryAircraftRepository : IAircraftRepository
    {
        // A list of aircrafts initialized with some sample data
        private readonly List<Aircraft> _aircraft = new List<Aircraft>
        {
             new Aircraft { Id = 1, Name = "F-22 Raptor", Manufacturer = "Lockheed Martin", Country = "United States", Role = "Air Superiority Fighter", TopSpeed = 1498, Price = 150000000 },
             new Aircraft { Id = 2, Name = "F-35 Lightning II", Manufacturer = "Lockheed Martin", Country = "United States", Role = "Stealth Multirole Fighter", TopSpeed = 1200, Price = 85000000 },
             new Aircraft { Id = 3, Name = "Sukhoi Su-35", Manufacturer = "Sukhoi", Country = "Russia", Role = "Multirole Fighter", TopSpeed = 2400, Price = 85000000 },
             new Aircraft { Id = 4, Name = "Su-57", Manufacturer = "Sukhoi", Country = "Russia", Role = "Air Superiority Fighter", TopSpeed = 1520, Price = 70000000 },
             new Aircraft { Id = 5, Name = "Eurofighter Typhoon", Manufacturer = "Airbus, BAE Systems, Leonardo, and others", Country = "European consortium (Germany, Spain, Italy, and the United Kingdom)", Role = "Multirole Fighter", TopSpeed = 1550, Price = 100000000 },
             new Aircraft { Id = 6, Name = "F-15 Eagle", Manufacturer = "Boeing", Country = "United States", Role = "Air Superiority Fighter", TopSpeed = 1650, Price = 30000000 },
             new Aircraft { Id = 7, Name = "Rafale", Manufacturer = "Dassault Aviation", Country = "France", Role = "Multirole Fighter", TopSpeed = 1912, Price = 80000000 },
             new Aircraft { Id = 8, Name = "Dassault Mirage 2000", Manufacturer = "Dassault Aviation", Country = "France", Role = "Multirole Fighter", TopSpeed = 2336, Price = 1000000 },
             new Aircraft { Id = 9, Name = "Chengdu J-10", Manufacturer = "Chengdu Aircraft Industry Group", Country = "China", Role = "Multirole Fighter", TopSpeed = 2335, Price = 60000000 },
             new Aircraft { Id = 10, Name = "J-20", Manufacturer = "Chengdu Aerospace Corporation", Country = "China", Role = "Air Superiority Fighter", TopSpeed = 1305, Price = 110000000 },
             new Aircraft { Id = 11, Name = "Gripen E", Manufacturer = "Saab", Country = "Sweden", Role = "Multirole Fighter", TopSpeed = 1372, Price = 85000000 },
             new Aircraft { Id = 12, Name = "MiG-35", Manufacturer = "Mikoyan", Country = "Russia", Role = "Multirole Fighter", TopSpeed = 1491, Price = 40000000 },
             new Aircraft { Id = 13, Name = "F/A-18 Super Hornet", Manufacturer = "Boeing", Country = "United States", Role = "Multirole Fighter", TopSpeed = 1190, Price = 70000000 },
             new Aircraft { Id = 14, Name = "HAL Tejas", Manufacturer = "Hindustan Aeronautics Limited (HAL)", Country = "India", Role = "Multirole Fighter", TopSpeed = 1370, Price = 40000000 },
             new Aircraft { Id = 15, Name = "Mitsubishi F-2", Manufacturer = "Mitsubishi Heavy Industries", Country = "Japan", Role = "Multirole Fighter", TopSpeed = 1860, Price = 100000000 },
             new Aircraft { Id = 16, Name = "JF-17 Thunder", Manufacturer = "Chengdu Aircraft Corporation (CAC) and Pakistan Aeronautical Complex (PAC)", Country = "Pakistan", Role = "Multirole Fighter", TopSpeed = 1975, Price = 25000000 },
             new Aircraft { Id = 17, Name = "HAL AMCA", Manufacturer = "Hindustan Aeronautics Limited (HAL)", Country = "India", Role = "Multirole Fighter", TopSpeed = 2485, Price = 120000000 },
             new Aircraft { Id = 18, Name = "T-50 PAK FA", Manufacturer = "Sukhoi", Country = "Russia", Role = "Air Superiority Fighter", TopSpeed = 2495, Price = 120000000 },
             new Aircraft { Id = 19, Name = "Chengdu J-7", Manufacturer = "Chengdu Aircraft Corporation", Country = "China", Role = "Interceptor Fighter", TopSpeed = 2330, Price = 20000000 },
             new Aircraft { Id = 20, Name = "Saab 37 Viggen", Manufacturer = "Saab", Country = "Sweden", Role = "Ground-Attack Aircraft", TopSpeed = 2350, Price = 30000000 },
             new Aircraft { Id = 21, Name = "Mikoyan MiG-29", Manufacturer = "Mikoyan", Country = "Russia", Role = "Multirole Fighter", TopSpeed = 2445, Price = 45000000 },
             new Aircraft { Id = 22, Name = "Chengdu J-9", Manufacturer = "Chengdu Aircraft Corporation", Country = "China", Role = "Stealth Multirole Fighter", TopSpeed = 2600, Price = 150000000 },
             new Aircraft { Id = 23, Name = "Sukhoi Su-30", Manufacturer = "Sukhoi", Country = "Russia", Role = "Multirole Fighter", TopSpeed = 2120, Price = 90000000 },
             new Aircraft { Id = 24, Name = "Northrop F-20 Tigershark", Manufacturer = "Northrop Corporation", Country = "United States", Role = "Lightweight Fighter", TopSpeed = 2290, Price = 35000000 }
        };

        // Asynchronously retrieves a paginated list of aircraft based on the provided filter criteria.
        // Supports filtering by name, manufacturer, country, role, top speed range, and price range.
        // Returns a paginated subset of the filtered results.
        public async Task<IEnumerable<Aircraft>> GetAircraftAsync(int page, int pageSize, AircraftFilter filter)
        {
            // Create a queryable collection from the in-memory list of aircraft.
            var query = _aircraft.AsQueryable();

            // Apply filtering based on the provided filter criteria.
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

            // Skip the records for the current page and take the specified number of records for the page.
            return await Task.FromResult(query.Skip((page - 1) * pageSize).Take(pageSize).ToList());
        }

        // Asynchronously retrieves an aircraft by its unique identifier (ID).
        // Returns the aircraft if found, otherwise returns null.
        public async Task<Aircraft> GetAircraftByIdAsync(int id)
        {
            return await Task.FromResult(_aircraft.FirstOrDefault(a => a.Id == id));
        }
    }
}