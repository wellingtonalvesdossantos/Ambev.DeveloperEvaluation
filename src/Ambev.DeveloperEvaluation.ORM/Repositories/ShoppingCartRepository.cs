using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Extensions;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IShoppingCartRepository using Entity Framework Core
/// </summary>
public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of ShoppingCartRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ShoppingCartRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new shoppingCart in the database
    /// </summary>
    /// <param name="shoppingCart">The shoppingCart to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created shoppingCart</returns>
    public async Task<ShoppingCart> CreateAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken = default)
    {
        await _context.ShoppingCarts.AddAsync(shoppingCart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return shoppingCart;
    }

    /// <summary>
    /// Retrieves a shoppingCart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the shoppingCart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The shoppingCart if found, null otherwise</returns>
    public async Task<ShoppingCart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.ShoppingCarts.Include("Items.Product").FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Deletes a shoppingCart from the database
    /// </summary>
    /// <param name="id">The unique identifier of the shoppingCart to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the shoppingCart was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var shoppingCart = await GetByIdAsync(id, cancellationToken);
        if (shoppingCart == null)
            return false;

        _context.ShoppingCarts.Remove(shoppingCart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public IQueryable<ShoppingCart> GetPaginated(PaginatedSearchBase paginationParams, Guid[]? customerList, Guid[]? productList)
    {
        var query = _context.ShoppingCarts.AsQueryable();

        //if (customerList != null && customerList.Length > 0)
        //    query = query.Where(u => customerList.Contains(u.CustomerId));

        if (productList != null && productList.Length > 0)
            query = query.Where(u => u.Items.Any(i => productList.Contains(i.ProductId)));

        return query.Include("Items.Product");
    }
}
