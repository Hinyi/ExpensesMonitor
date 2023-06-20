namespace ExpensesMonitor.Domain.ValueObjects;

public record Price(string Currency, decimal Amount)
{
    public static Price Create(string value)
    {
        var splitPrice = value.Split(",");
        return new Price(splitPrice.First(), Convert.ToDecimal(splitPrice.Last()));
    }

    public override string ToString()
        => $"{Currency},{Amount}";
}