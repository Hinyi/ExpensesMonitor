using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Domain;
using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.Repositories;
using ExpensesMonitor.Infrastructure.EF.Models;
using ExpensesMonitor.Shared.DTO;
using ExpensesMonitor.Shared.Queries;
using MediatR;

namespace ExpensesMonitor.Application.Queries.GetAllShoppingLists;

public class GetAllShoppingListsHandler : IRequestHandler<GetAllShoppingLists, IEnumerable<ShoppingListDto>>
{
    private readonly IShoppingListReadService _service;

    public GetAllShoppingListsHandler(IShoppingListReadService service)
    {
        _service = service;
    }

    // public async Task<ShoppingList> HandleAsync(GetAllShoppingLists query)
    // {
    //     
    // }

    public async Task<IEnumerable<ShoppingListDto>> Handle(GetAllShoppingLists request, CancellationToken cancellationToken)
    {
        var result = _service.GetAllAsync();

        return await result;
    }
}