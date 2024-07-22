using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Infrastructure.Repositories
{
    public class InMemoryBasketRepository : IBasketRepository
    {
        private readonly Dictionary<string, Basket> _baskets = new Dictionary<string, Basket>();

        public async Task<Basket> GetBasketAsync(string customerId)
        {
            if (!_baskets.TryGetValue(customerId, out var basket))
            {
                basket = new Basket { CustomerId = customerId };
                _baskets[customerId] = basket;
            }

            return await Task.FromResult(basket);
        }

        public async Task UpdateBasketAsync(Basket basket)
        {
            _baskets[basket.CustomerId] = basket;
            await Task.CompletedTask;
        }
    }
}