using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Infrastructure.Repositories
{
    /// <summary>
    /// In-memory implementation of the IOrderRepository interface.
    /// This repository stores orders in memory for testing or simple scenarios.
    /// </summary>
    public class InMemoryOrderRepository : IOrderRepository
    {
        // List to store orders in memory
        private readonly List<Order> _orders = new List<Order>();

        // Counter to assign unique IDs to orders
        private int _nextOrderId = 1;

        /// <summary>
        /// Asynchronously creates a new order and adds it to the in-memory list.
        /// The order's ID is automatically generated.
        /// </summary>
        /// <param name="order">The order to be created.</param>
        /// <returns>A task that represents the asynchronous operation. 
        /// The task result contains the ID of the newly created order.</returns>
        public async Task<int> CreateOrderAsync(Order order)
        {
            // Assign a unique ID to the order
            order.Id = _nextOrderId++;

            // Add the order to the in-memory list
            _orders.Add(order);

            // Return the ID of the newly created order
            return await Task.FromResult(order.Id);
        }
    }
}
