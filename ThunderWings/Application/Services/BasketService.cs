using System.Linq;
using System.Threading.Tasks;
using ThunderWings.Application.Interfaces;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Application.Services
{
    public class BasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IAircraftRepository _aircraftRepository;

        public BasketService(IBasketRepository basketRepository, IAircraftRepository aircraftRepository)
        {
            _basketRepository = basketRepository;
            _aircraftRepository = aircraftRepository;
        }

        public async Task<Basket> GetBasketAsync(string customerId)
        {
            return await _basketRepository.GetBasketAsync(customerId);
        }

        public async Task AddToBasketAsync(string customerId, int aircraftId, int quantity)
        {
            var basket = await _basketRepository.GetBasketAsync(customerId);
            var existingItem = basket.Items.FirstOrDefault(i => i.AircraftId == aircraftId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                basket.Items.Add(new BasketItem { AircraftId = aircraftId, Quantity = quantity });
            }

            await _basketRepository.UpdateBasketAsync(basket);
        }

        public async Task RemoveFromBasketAsync(string customerId, int aircraftId)
        {
            var basket = await _basketRepository.GetBasketAsync(customerId);
            basket.Items.RemoveAll(i => i.AircraftId == aircraftId);
            await _basketRepository.UpdateBasketAsync(basket);
        }
    }
}