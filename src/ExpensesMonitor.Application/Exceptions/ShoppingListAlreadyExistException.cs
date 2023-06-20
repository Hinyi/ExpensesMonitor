using System.Net;
using ExpensesMonitor.Shared.Exceptions;

namespace ExpensesMonitor.Application.Exceptions;

public class ShoppingListAlreadyExistException : ExpensesMonitorException
{
    public string Name { get; }
    public ShoppingListAlreadyExistException(string name) : base(name)
    {
        Name = name;
    }

    public override HttpStatusCode StatusCode { get; }
}