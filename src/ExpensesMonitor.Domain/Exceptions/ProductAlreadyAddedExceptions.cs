using System.Net;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Exceptions;

namespace ExpensesMonitor.Domain.Exceptions;

public class ProductAlreadyAddedExceptions : ExpensesMonitorException
{
    public string ShoppingListName { get; }
    public ProductName Item { get; }

    public ProductAlreadyAddedExceptions(string shoppingListName ,ProductName item) 
        : base($"{shoppingListName} : {item} is already in list")
    {
        ShoppingListName = shoppingListName;
        Item = item;
    }

    public override HttpStatusCode StatusCode { get; }
}