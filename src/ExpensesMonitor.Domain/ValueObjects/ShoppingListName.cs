using ExpensesMonitor.Domain.Exceptions;

namespace ExpensesMonitor.Domain.ValueObjects;

public record ShoppingListName
{
    public ShoppingListName(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new EmptyShoppingListNameException();
        Value = value;
    }

    public string Value { get; }

    public static implicit operator string(ShoppingListName name)
        => name.Value;

    public static implicit operator ShoppingListName(string name)
        => new(name);
}