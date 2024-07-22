using System.Threading.Tasks;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> CreateOrderAsync(Order order);
    }
}