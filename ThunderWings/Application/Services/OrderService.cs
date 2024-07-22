using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IAircraftRepository _aircraftRepository;

        public OrderService(IOrderRepository orderRepository, IBasketRepository basketRepository, IAircraftRepository aircraftRepository)
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _aircraftRepository = aircraftRepository;
        }

        public async Task<int> CreateOrderAsync(string customerId)
        {
            var basket = await _basketRepository.GetBasketAsync(customerId);

            if (basket.Items.Count == 0)
            {
                throw new Exception("Basket is empty");
            }

            var order = new Order
            {
                CustomerId = customerId,
                OrderDate = DateTime.UtcNow,
                Items = new List<OrderItem>()
            };

            decimal totalPrice = 0;
           
                foreach (var item in basket.Items)
                {
                    var aircraft = await _aircraftRepository.GetAircraftByIdAsync(item.AircraftId);
                    var orderItem = new OrderItem
                    {
                        AircraftId = item.AircraftId,
                        Quantity = item.Quantity,
                        Price = aircraft.Price
                    };
                    order.Items.Add(orderItem);
                    totalPrice += orderItem.Price * orderItem.Quantity;
                }
           
           
            order.TotalPrice = totalPrice;

            var orderId = await _orderRepository.CreateOrderAsync(order);

            // Clear the basket after creating the order
            basket.Items.Clear();
            await _basketRepository.UpdateBasketAsync(basket);

            return orderId;
        }
    }
}