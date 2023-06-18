namespace ExpensesMonitor.Domain.ValueObjects;

public record ProductList(string Name, int Quantity, Price Price)
{
    private readonly decimal TotalPrice = Quantity * Price.Amount;
}