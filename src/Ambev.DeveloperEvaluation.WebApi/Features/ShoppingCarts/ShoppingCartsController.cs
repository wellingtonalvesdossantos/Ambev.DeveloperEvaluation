using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.GetCart;
using Ambev.DeveloperEvaluation.WebApi.Features.ShoppingCarts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.ShoppingCarts.CreateCart;
using Ambev.DeveloperEvaluation.Application.ShoppingCarts.GetCart;
using Ambev.DeveloperEvaluation.Application.ShoppingCarts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.ShoppingCarts.FilterCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.FilterCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts;

/// <summary>
/// Controller for managing Cart operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ShoppingCartsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ShoppingCartsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ShoppingCartsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new Cart
    /// </summary>
    /// <param name="request">The Cart creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Cart details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateCartCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateCartResponse>
        {
            Success = true,
            Message = "Cart created successfully",
            Data = _mapper.Map<CreateCartResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a Cart by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the Cart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Cart details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCartResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCart([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetCartRequest { Id = id };
        var validator = new GetCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetCartCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return new OkObjectResult(new ApiResponseWithData<GetCartResponse>
        {
            Success = true,
            Message = "Cart retrieved successfully",
            Data = _mapper.Map<GetCartResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves Carts 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(FilterCartResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPaginated([FromQuery] FilterCartRequest request, CancellationToken cancellationToken)
    {
        var validator = new FilterCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<FilterCartCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);

        return new OkObjectResult(FilterCartResponse.Create(result, _mapper));
    }

    /// <summary>
    /// Deletes a Cart by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the Cart to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the Cart was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCart([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteCartRequest { Id = id };
        var validator = new DeleteCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteCartCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Cart deleted successfully"
        });
    }
}
