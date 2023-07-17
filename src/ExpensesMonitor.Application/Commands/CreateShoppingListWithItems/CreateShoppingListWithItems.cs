using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Commands;
using MediatR;
using Gender = ExpensesMonitor.Domain.Const.Gender;


namespace ExpensesMonitor.Application.Commands.CreateShoppingListWithItems;

public record CreateShoppingListWithItems(string Name,
    OccasionWriteModel Occasion, Gender gender) : IRequest<ShoppingListResponse>;

public record OccasionWriteModel(string occasion);