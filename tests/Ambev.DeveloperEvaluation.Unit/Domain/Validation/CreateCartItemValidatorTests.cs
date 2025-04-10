using Ambev.DeveloperEvaluation.Application.ShoppingCarts.CreateCart;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    public class CreateCartItemValidatorTests
    {
        private readonly CreateCartItemValidator _validator;

        public CreateCartItemValidatorTests()
        {
            _validator = new CreateCartItemValidator();
        }

        [Fact]
        public void Should_Have_Error_When_ProductId_Is_Empty()
        {
            // Arrange
            var command = new CreateCartItemCommand
            {
                ProductId = Guid.Empty,
                Quantity = 1
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result
                .IsValid
                .Should()
                .BeFalse();
        }

        [Fact]
        public void Should_Have_Error_When_Quantity_Is_Less_Than_One()
        {
            // Arrange
            var command = new CreateCartItemCommand
            {
                ProductId = Guid.NewGuid(),
                Quantity = 0
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result
                .IsValid
                .Should()
                .BeFalse();
        }

        [Fact]
        public void Should_Have_Error_When_Quantity_Is_More_Than_Twenty()
        {
            // Arrange
            var command = new CreateCartItemCommand
            {
                ProductId = Guid.NewGuid(),
                Quantity = 21
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result
                .IsValid
                .Should()
                .BeFalse();
        }

        [Fact]
        public void Should_Not_Have_Error_When_Command_Is_Valid()
        {
            // Arrange
            var command = new CreateCartItemCommand
            {
                ProductId = Guid.NewGuid(),
                Quantity = 5
            };

            // Act
            var result = _validator.Validate(command);

            // Assert
            result
                .IsValid
                .Should()
                .BeTrue();
        }
    }
}
