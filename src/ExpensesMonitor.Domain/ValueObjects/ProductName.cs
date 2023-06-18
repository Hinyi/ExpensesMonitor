namespace ExpensesMonitor.Domain.ValueObjects;

public record ProductName()
{
    public string Name { get; }

    public ProductName(string name) : this()
    {
        Name = name;
    }
}