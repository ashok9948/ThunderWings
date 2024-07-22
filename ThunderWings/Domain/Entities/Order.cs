using System;
using System.Collections.Generic;

namespace ThunderWings.Domain.Entities
{
    // Represents an order placed by a customer
    public class Order
    {
        // Unique identifier for the order
        public int Id { get; set; }

        // Identifier for the customer who placed the order
        public string CustomerId { get; set; }

        // List of items included in the order
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        // Total price of the order
        public decimal TotalPrice { get; set; }

        // Date and time when the order was placed
        public DateTime OrderDate { get; set; }
    }

    // Represents an item within an order
    public class OrderItem
    {
        // Identifier for the aircraft associated with this order item
        public int AircraftId { get; set; }

        // Quantity of the aircraft ordered
        public int Quantity { get; set; }

        // Price of a single unit of the aircraft
        public decimal Price { get; set; }
    }
}
