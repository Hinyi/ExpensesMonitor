using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Commands;
using Gender = ExpensesMonitor.Domain.Const.Gender;

namespace ExpensesMonitor.Application.Commands.CreateShoppingListWithItems;

public record CreateShoppingListWithItems(Guid Id, string name,
    Occasion occasion, Gender gender) : ICommand;
    