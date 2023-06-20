using ExpensesMonitor.Shared.Commands;

namespace ExpensesMonitor.Application.Commands.AddProductsToList;

public record AddProductsToList(Guid PackingListId, string name, uint Quantity) : ICommand;