namespace ThunderWings.Domain.Entities
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public double TopSpeed { get; set; }
        public decimal Price { get; set; }
    }
}
