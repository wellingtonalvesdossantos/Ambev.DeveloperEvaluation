using Ambev.DeveloperEvaluation.Application.ShoppingCarts.CreateCart;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    public class CreateCartValidatorTests
    {
        private readonly CreateCartValidator _validator;

        public CreateCartValidatorTests()
        {
            _validator = new CreateCartValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Branch_Is_Empty()
        {
            // Arrange
            var command = new CreateCartCommand
            {
                Branch = string.Empty,
                Items = new List<CreateCartItemCommand>
                {
                    new CreateCartItemCommand
                    {
                        ProductId = Guid.NewGuid(),
                        Quantity = 1
                    }
                }
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
        public void Should_Have_Error_When_Items_Is_Empty()
        {
            // Arrange
            var command = new CreateCartCommand
            {
                Branch = "branch",
                Items = []
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
        public void Should_Not_Have_Error_When_Cart_Is_Valid()
        {
            // Arrange
            var command = new CreateCartCommand
            {
                Branch = "branch",
                Items = new List<CreateCartItemCommand>
                {
                    new CreateCartItemCommand
                    {
                        ProductId = Guid.NewGuid(),
                        Quantity = 1
                    }
                }
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
