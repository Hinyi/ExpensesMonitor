using System.Net;
using ExpensesMonitor.Shared.Exceptions;

namespace ExpensesMonitor.Domain.Exceptions;

public class EmptyShoppingListNameException : ExpensesMonitorException
{
    public EmptyShoppingListNameException() : base("Shopping list name cannot be empty")
    {
    }

    public override HttpStatusCode StatusCode { get; }
}