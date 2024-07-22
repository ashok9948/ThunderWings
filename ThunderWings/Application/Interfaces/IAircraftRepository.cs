using System.Collections.Generic;
using System.Threading.Tasks;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for interacting with aircraft data.
    /// This interface includes methods for retrieving aircraft information,
    /// both as a paged list and by individual identifiers.
    /// </summary>
    public interface IAircraftRepository
    {
        /// <summary>
        /// Retrieves a paged list of aircraft based on the provided filtering criteria.
        /// </summary>
        /// <param name="page">The page number to retrieve (1-based index).</param>
        /// <param name="pageSize">The number of items to include per page.</param>
        /// <param name="filter">The filtering criteria used to narrow down the list of aircraft.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable list of aircraft.</returns>
        Task<IEnumerable<Aircraft>> GetAircraftAsync(int page, int pageSize, AircraftFilter filter);

        /// <summary>
        /// Retrieves a specific aircraft by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the aircraft.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the aircraft with the specified identifier.</returns>
        Task<Aircraft> GetAircraftByIdAsync(int id);
    }

    /// <summary>
    /// Represents the criteria used to filter aircraft results.
    /// This class includes various properties to filter the aircraft based on name, manufacturer, country, role, speed, and price.
    /// </summary>
    public class AircraftFilter
    {
        /// <summary>
        /// Gets or sets the name of the aircraft to filter by.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer of the aircraft to filter by.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the country of origin of the aircraft to filter by.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the role of the aircraft to filter by.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the minimum top speed of the aircraft to filter by.
        /// </summary>
        public double? MinTopSpeed { get; set; }

        /// <summary>
        /// Gets or sets the maximum top speed of the aircraft to filter by.
        /// </summary>
        public double? MaxTopSpeed { get; set; }

        /// <summary>
        /// Gets or sets the minimum price of the aircraft to filter by.
        /// </summary>
        public decimal? MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the maximum price of the aircraft to filter by.
        /// </summary>
        public decimal? MaxPrice { get; set; }
    }
}
