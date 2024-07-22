using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Application.Services
{
    /// <summary>
    /// Service for handling order-related operations.
    /// </summary>
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IAircraftRepository _aircraftRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="orderRepository">Repository for managing orders.</param>
        /// <param name="basketRepository">Repository for managing customer baskets.</param>
        /// <param name="aircraftRepository">Repository for managing aircraft details.</param>
        public OrderService(IOrderRepository orderRepository, IBasketRepository basketRepository, IAircraftRepository aircraftRepository)
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _aircraftRepository = aircraftRepository;
        }

        /// <summary>
        /// Creates a new order based on the items in the customer's basket.
        /// </summary>
        /// <param name="customerId">The ID of the customer placing the order.</param>
        /// <returns>The ID of the newly created order.</returns>
        /// <exception cref="Exception">Thrown when the basket is empty.</exception>
        public async Task<int> CreateOrderAsync(string customerId)
        {
            // Retrieve the basket for the specified customer
            var basket = await _basketRepository.GetBasketAsync(customerId);

            // Check if the basket is empty and throw an exception if true
            if (basket.Items.Count == 0)
            {
                throw new Exception("Basket is empty");
            }

            // Create a new order object
            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow,
                Items = new List<OrderItem>()
            };

            decimal totalPrice = 0;

            // Iterate over each item in the basket and add to the order
            foreach (var item in basket.Items)
            {
                // Retrieve details of the aircraft for the item
                var aircraft = await _aircraftRepository.GetAircraftByIdAsync(item.AircraftId);

                // Create an order item for the current basket item
                var orderItem = new OrderItem
                {
                    AircraftId = item.AircraftId,
                    Quantity = item.Quantity,
                    Price = aircraft.Price
                };

                // Add the order item to the order and update the total price
                order.Items.Add(orderItem);
                totalPrice += orderItem.Price * orderItem.Quantity;
            }

            // Set the total price for the order
            order.TotalPrice = totalPrice;

            // Save the order to the repository and get the order ID
            var orderId = await _orderRepository.CreateOrderAsync(order);

            // Clear the basket items after creating the order
            basket.Items.Clear();
            await _basketRepository.UpdateBasketAsync(basket);

            // Return the ID of the newly created order
            return orderId;
        }
    }
}
