using ExpensesMonitor.Domain.Exceptions;

namespace ExpensesMonitor.Domain.ValueObjects;

public record ShoppingListId //: IEquatable<ShoppingListId>
{
    public Guid Value { get; init; } 

    public ShoppingListId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyShoppingListIdException();
        }

        Value = value;
    }
    

    // public bool Equals(ShoppingListId? other)
    // {
    //     if (ReferenceEquals(null, other)) return false;
    //     return ReferenceEquals(this, other) || Value.Equals(other.Value);    
    // }
    //
    // public override bool Equals(object obj)
    // {
    //     if (ReferenceEquals(null, obj)) return false;
    //     if (ReferenceEquals(this, obj)) return true;
    //     return obj.GetType() == GetType() && Equals((ShoppingListId)obj);
    // }
    
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value.ToString();
    public static implicit operator Guid(ShoppingListId id)
        => id.Value;
    public static implicit operator ShoppingListId(Guid id)
        => new(id);
}
