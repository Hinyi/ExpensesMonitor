using System.Net;
using ExpensesMonitor.Shared.Exceptions;

namespace ExpensesMonitor.Domain.Exceptions;

public class EmptyShoppingListIdException : ExpensesMonitorException
{
    public EmptyShoppingListIdException() : base("ShoppingListId cannot be empty")
    {
    }

    public override HttpStatusCode StatusCode { get; }
}