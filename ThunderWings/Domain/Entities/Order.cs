using System;
using System.Collections.Generic;

namespace ThunderWings.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class OrderItem
    {
        public int AircraftId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}