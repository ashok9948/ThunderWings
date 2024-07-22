using System.Collections.Generic;

namespace ThunderWings.Domain.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
    public class BasketItem
    {
        public int AircraftId { get; set; }
        public int Quantity { get; set; }
    }
}