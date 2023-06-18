namespace ExpensesMonitor.Domain.ValueObjects;

public record Gender
{
    public string Value { get; }

    public Gender(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new Exception();
        Value = value;
    }
    
    public static implicit operator string(Gender value) => value.Value;
    public static implicit operator Gender(string value) => new(value);
}