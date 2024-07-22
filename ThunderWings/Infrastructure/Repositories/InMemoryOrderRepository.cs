using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Infrastructure.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new List<Order>();
        private int _nextOrderId = 1;

        public async Task<int> CreateOrderAsync(Order order)
        {
            order.Id = _nextOrderId++;
            _orders.Add(order);
            return await Task.FromResult(order.Id);
        }
    }
}