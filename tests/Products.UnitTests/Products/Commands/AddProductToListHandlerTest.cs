using System.Net.Mime;
using ExpensesMonitor.Application.Commands.AddProductsToList;
using ExpensesMonitor.Application.Exceptions;
using ExpensesMonitor.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Products.UnitTests.Products.Commands;

public class AddProductToListHandlerTest
{
    private readonly Mock<IShoppingListRepository> _repository;
    
    public AddProductToListHandlerTest(IShoppingListRepository repository)
    {
        _repository = new();
    }
    
    // [Fact]
    // public async Task Handle_Should_ReturnFailureResult_WhenShoppingListIsEmpty()
    // {
    //     //Arrange
    //     var command = new AddProductsToList(new Guid(), "czekolada", 2, new PriceWriteModel("pln",12));
    //
    //     var handler = new AddProductsToListHandler(_repository.Object);
    //     //Act
    //     await handler.HandleAsync(command);
    //     //Assert
    //     handler.Should().NotBeOfType<ShoppingListAlreadyExistException>();
    // }
}