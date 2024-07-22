using System.Collections.Generic;
using System.Threading.Tasks;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Application.Interfaces
{
    public interface IAircraftRepository
    {
        Task<IEnumerable<Aircraft>> GetAircraftAsync(int page, int pageSize, AircraftFilter filter);
        Task<Aircraft> GetAircraftByIdAsync(int id);
    }

    public class AircraftFilter
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public double? MinTopSpeed { get; set; }
        public double? MaxTopSpeed { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}