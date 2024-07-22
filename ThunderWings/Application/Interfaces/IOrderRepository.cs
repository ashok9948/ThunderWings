using System.Threading.Tasks;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Application.Interfaces
{
    /// <summary>
    /// Interface for handling order-related data operations.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Asynchronously creates a new order in the repository.
        /// </summary>
        /// <param name="order">The order entity to be created.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the ID of the created order.</returns>
        Task<int> CreateOrderAsync(Order order);
    }
}
