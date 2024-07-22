using System.Threading.Tasks;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Application.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketAsync(string customerId);
        Task UpdateBasketAsync(Basket basket);
    }
}