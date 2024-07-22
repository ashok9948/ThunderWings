using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Infrastructure.Repositories
{
    // InMemoryBasketRepository provides an in-memory implementation of the IBasketRepository interface
    // This implementation stores basket data in a Dictionary for simplicity and quick access.
    public class InMemoryBasketRepository : IBasketRepository
    {
        // Dictionary to hold baskets, keyed by the customer ID
        private readonly Dictionary<string, Basket> _baskets = new Dictionary<string, Basket>();

        // Asynchronously retrieves a basket for a given customer ID
        // If the basket does not exist, it creates a new one and adds it to the dictionary
        public async Task<Basket> GetBasketAsync(string customerId)
        {
            // Try to get the basket from the dictionary
            if (!_baskets.TryGetValue(customerId, out var basket))
            {
                // If not found, create a new basket for the customer and add it to the dictionary
                basket = new Basket { CustomerId = customerId };
                _baskets[customerId] = basket;
            }

            // Return the basket asynchronously
            return await Task.FromResult(basket);
        }

        // Asynchronously updates the basket in the dictionary
        public async Task UpdateBasketAsync(Basket basket)
        {
            // Update or add the basket in the dictionary
            _baskets[basket.CustomerId] = basket;
            // Complete the task asynchronously
            await Task.CompletedTask;
        }
    }
}
