namespace ThunderWings.Domain.Entities
{
    /// <summary>
    /// Represents an aircraft entity within the Thunder Wings domain.
    /// </summary>
    public class Aircraft
    {
        /// <summary>
        /// Gets or sets the unique identifier for the aircraft.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the aircraft.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer of the aircraft.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the country of origin for the aircraft.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the primary role or function of the aircraft.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the top speed of the aircraft in miles per hour.
        /// </summary>
        public double TopSpeed { get; set; }

        /// <summary>
        /// Gets or sets the price of the aircraft.
        /// </summary>
        public decimal Price { get; set; }
    }
}
