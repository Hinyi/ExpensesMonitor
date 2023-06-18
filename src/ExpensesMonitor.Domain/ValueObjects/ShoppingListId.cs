using ExpensesMonitor.Domain.Exceptions;

namespace ExpensesMonitor.Domain.ValueObjects;

public record ShoppingListId
{
    public Guid Value { get; }

    public ShoppingListId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyShoppingListIdException();
        }

        Value = value;
    }
    
    public static implicit operator Guid(ShoppingListId id)
        => id.Value;
        
    public static implicit operator ShoppingListId(Guid id)
        => new(id);
}