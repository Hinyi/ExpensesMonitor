namespace ExpensesMonitor.Domain.ValueObjects;

public record Occasion()
{
    public string Value { get; }

    public Occasion(string value) : this()
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new Exception();
        }
        Value = value;
    }
    
    public static implicit operator string(Occasion occasion)
        => occasion.Value;
        
    public static implicit operator Occasion(string occasion)
        => new(occasion);
}