using System.Threading.Tasks;
using ThunderWings.Domain.Entities;

namespace ThunderWings.Application.Interfaces
{
    /// <summary>
    /// Interface for repository operations related to baskets.
    /// </summary>
    public interface IBasketRepository
    {
        /// <summary>
        /// Asynchronously retrieves the basket for a specified customer.
        /// </summary>
        /// <param name="customerId">The unique identifier of the customer.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the customer's basket.</returns>
        Task<Basket> GetBasketAsync(string customerId);

        /// <summary>
        /// Asynchronously updates the specified basket in the repository.
        /// </summary>
        /// <param name="basket">The basket object containing the updated information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateBasketAsync(Basket basket);
    }
}
