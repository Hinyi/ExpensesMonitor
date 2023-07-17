using ExpensesMonitor.Domain.Exceptions;

namespace ExpensesMonitor.Domain.ValueObjects;

public record ShoppingListName
{
    public string Value { get; init; }
    
    public ShoppingListName(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new EmptyShoppingListNameException();
        Value = value;
    }
    
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value.ToString();
    
    public static implicit operator string(ShoppingListName name)
        => name.Value;

    public static implicit operator ShoppingListName(string name)
        => new(name);
}