using System.Collections.Generic;

namespace ThunderWings.Domain.Entities
{
    /// <summary>
    /// Represents a shopping basket for a customer, containing items they wish to purchase.
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// Gets or sets the unique identifier for the basket.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the customer who owns the basket.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the list of items in the basket.
        /// </summary>
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }

    /// <summary>
    /// Represents an item in the basket, including the aircraft and its quantity.
    /// </summary>
    public class BasketItem
    {
        /// <summary>
        /// Gets or sets the unique identifier for the aircraft.
        /// </summary>
        public int AircraftId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the aircraft in the basket.
        /// </summary>
        public int Quantity { get; set; }
    }
}
