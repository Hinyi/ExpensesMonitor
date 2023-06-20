using System.Net;
using ExpensesMonitor.Shared.Exceptions;

namespace ExpensesMonitor.Application.Exceptions;

public class ShoppingListNotFoundException : ExpensesMonitorException
{
    public Guid Id { get; }
    
    public ShoppingListNotFoundException(Guid id) : base(id.ToString())
    {
        Id = id;
    }

    public override HttpStatusCode StatusCode { get; }
}