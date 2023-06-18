using System.Net;
using ExpensesMonitor.Shared.Exceptions;

namespace ExpensesMonitor.Domain.ValueObjects;

public record Quantity
{
    public float Amount { get; }

    public Quantity(float amount)
    {
        if (amount < 0)
            throw new Exception();
        Amount = amount;
    }
}

internal class InvalidQuantityException : ExpensesMonitorException
{
    public float Quantity { get; }
    
    public InvalidQuantityException(float quantity) : base($"Quantity can't be less than 0. Amount: {quantity}")
        => Quantity = quantity;

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}