using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for ShoppingCart entity operations
/// </summary>
public interface IShoppingCartRepository
{
    /// <summary>
    /// Creates a new ShoppingCart in the repository
    /// </summary>
    /// <param name="shoppingCart">The ShoppingCart to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created ShoppingCart</returns>
    Task<ShoppingCart> CreateAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a ShoppingCart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the ShoppingCart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The ShoppingCart if found, null otherwise</returns>
    Task<ShoppingCart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a ShoppingCart from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the ShoppingCart to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the ShoppingCart was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    IQueryable<ShoppingCart> GetPaginated(PaginatedSearchBase paginationParams, Guid[]? customerList, Guid[]? productList);
}
