using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Product entity operations
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Creates a new Product in the repository
    /// </summary>
    /// <param name="product">The Product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Product</returns>
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a Product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Product if found, null otherwise</returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<ICollection<Product>> GetByIdsAsync(ICollection<Guid> ids, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a Product from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the Product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Product was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    IQueryable<Product> GetPaginated(PaginatedSearchBase paginationParams);
}
