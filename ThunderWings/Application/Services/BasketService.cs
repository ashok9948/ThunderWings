using System.Linq;
using System.Threading.Tasks;
using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Application.Services
{
    public class BasketService
    {
        // Fields for repositories used by the service
        private readonly IBasketRepository _basketRepository;
        private readonly IAircraftRepository _aircraftRepository;

        // Constructor to inject dependencies for basket and aircraft repositories
        public BasketService(IBasketRepository basketRepository, IAircraftRepository aircraftRepository)
        {
            _basketRepository = basketRepository;
            _aircraftRepository = aircraftRepository;
        }

        // Method to retrieve a customer's basket asynchronously
        public async Task<Basket> GetBasketAsync(string customerId)
        {
            return await _basketRepository.GetBasketAsync(customerId);
        }

        // Method to add an item to the customer's basket asynchronously
        public async Task AddToBasketAsync(string customerId, int aircraftId, int quantity)
        {
            // Retrieve the current basket for the customer
            var basket = await _basketRepository.GetBasketAsync(customerId);

            // Check if the item already exists in the basket
            var existingItem = basket.Items.FirstOrDefault(i => i.AircraftId == aircraftId);

            if (existingItem != null)
            {
                // If the item exists, update its quantity
                existingItem.Quantity += quantity;
            }
            else
            {
                // If the item does not exist, add it to the basket
                basket.Items.Add(new BasketItem { AircraftId = aircraftId, Quantity = quantity });
            }

            // Update the basket in the repository
            await _basketRepository.UpdateBasketAsync(basket);
        }

        // Method to remove an item from the customer's basket asynchronously
        public async Task RemoveFromBasketAsync(string customerId, int aircraftId)
        {
            // Retrieve the current basket for the customer
            var basket = await _basketRepository.GetBasketAsync(customerId);

            // Remove the specified item from the basket
            basket.Items.RemoveAll(i => i.AircraftId == aircraftId);

            // Update the basket in the repository
            await _basketRepository.UpdateBasketAsync(basket);
        }
    }
}
