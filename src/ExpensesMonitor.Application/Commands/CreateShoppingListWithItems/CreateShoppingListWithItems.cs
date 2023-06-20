using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Commands;
using Gender = ExpensesMonitor.Domain.Const.Gender;


namespace ExpensesMonitor.Application.Commands.CreateShoppingListWithItems;

public record CreateShoppingListWithItems(Guid Id, string Name,
    OccasionWriteModel Occasion, Gender gender) : ICommand;

public record OccasionWriteModel(string occasion);
    