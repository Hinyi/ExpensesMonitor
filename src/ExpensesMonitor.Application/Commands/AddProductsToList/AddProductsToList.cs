using ExpensesMonitor.Shared.Commands;

namespace ExpensesMonitor.Application.Commands.AddProductsToList;

public record AddProductsToList(Guid shoppingListId, string name, 
    int Quantity, PriceWriteModel price) : ICommand;

public record PriceWriteModel(string currency, decimal amount);