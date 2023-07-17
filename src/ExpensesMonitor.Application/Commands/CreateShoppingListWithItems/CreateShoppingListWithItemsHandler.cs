using ExpensesMonitor.Application.Exceptions;
using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Domain;
using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.Repositories;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Commands;
using MediatR;

namespace ExpensesMonitor.Application.Commands.CreateShoppingListWithItems;

public class CreateShoppingListWithItemsHandler : IRequestHandler<CreateShoppingListWithItems, ShoppingListResponse>
{
    private readonly IShoppingListRepository _repository;
    private readonly IShoppingListFactory _factory;
    private readonly IShoppingListReadService _readService;

    public CreateShoppingListWithItemsHandler(IShoppingListRepository repository
        , IShoppingListFactory factory, IShoppingListReadService readService)
    {
        _repository = repository;
        _factory = factory;
        _readService = readService;
    }

    public async Task<ShoppingListResponse> Handle(CreateShoppingListWithItems command, CancellationToken cancellationToken)
    {
        //var (id, name, occasionWriteModel, gender) = command;
        
        if (await _readService.ExistByNameAsync(command.Name))
        {
            throw new ShoppingListAlreadyExistException(command.Name);
        }

        var occasion = new Occasion(command.Occasion.occasion);

        var shoppingListId = new ShoppingListId(Guid.NewGuid());

        var shoppinglist = _factory.CreateWithDefaultItems(shoppingListId, command.Name, occasion, command.gender);

        await _repository.AddAsync(shoppinglist);

        return new ShoppingListResponse(shoppingListId);
    }
}