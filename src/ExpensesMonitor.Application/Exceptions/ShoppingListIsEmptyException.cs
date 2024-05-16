using System.Net;
using ExpensesMonitor.Shared.Exceptions;

namespace ExpensesMonitor.Application.Exceptions;

public class ShoppingListIsEmptyException : ExpensesMonitorException
{
    public ShoppingListIsEmptyException(string message) : base(message)
    {
    }

    public override HttpStatusCode StatusCode { get; }
}