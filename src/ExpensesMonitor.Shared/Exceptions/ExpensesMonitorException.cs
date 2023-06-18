using System.Net;

namespace ExpensesMonitor.Shared.Exceptions;

public abstract class ExpensesMonitorException : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    protected ExpensesMonitorException(string message) : base(message)
    {
    }
}