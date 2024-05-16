using ExpensesMonitor.Application.Commands.CreateShoppingListWithItems;
using ExpensesMonitor.Application.Exceptions;
using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Domain;
using ExpensesMonitor.Domain.Const;
using ExpensesMonitor.Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Products.UnitTests.Products.Commands;

public class CreateShoppingListWithItemsTest
{
    private readonly Mock<IShoppingListRepository> _repository;
    private readonly Mock<IShoppingListFactory> _factory;
    private readonly Mock<IShoppingListReadService> _readService;

    public CreateShoppingListWithItemsTest()
    {
        _repository = new ();
        _factory = new ();
        _readService = new();
    }

    // [Fact]
    // public async Task Handle_Should_ReturnFailureResult_WhenNameIsNotUnique()
    // {
    //     //Arrange
    //     var command = new CreateShoppingListWithItems("party", new OccasionWriteModel("party"), Gender.Male);
    //
    //     _readService.Setup(
    //         x => x.ExistByNameAsync(
    //             It.IsAny<string>()))
    //         .ReturnsAsync(true);
    //     
    //     var handler = new CreateShoppingListWithItemsHandler(_repository.Object, _factory.Object, _readService.Object);
    //     //Act
    //     var result = await handler.Handle(command, default);
    //     //Assets
    //     result.Should().NotBeOfType<ShoppingListAlreadyExistException>();
    // }    
    //
    [Fact]
    public async Task Handle_Should_ReturneResultTrue_WhenNameIsUnique()
    {
        //Arrange
        var command = new CreateShoppingListWithItems("party", new OccasionWriteModel("party"), Gender.Male);

        _readService.Setup(
            x => x.ExistByNameAsync(
                It.IsAny<string>()))
            .ReturnsAsync(false);
         
        var handler = new CreateShoppingListWithItemsHandler(_repository.Object, _factory.Object, _readService.Object);
        //Act
        var result = await handler.Handle(command, default);
        //Assets
        result.Should().BeOfType<ShoppingListResponse>();
    }
}