using ExpensesMonitor.Domain.Exceptions;
using ExpensesMonitor.Domain.ValueObjects;

namespace ExpensesMonitor.Domain.Entities;

public class ShoppingList
{
    public Guid Id { get; private set; }
    public ShoppingListName Name { get; private set; }

    private readonly LinkedList<Product> _item = new();

    internal ShoppingList(Guid id, ShoppingListName name, LinkedList<Product> items)
    {
        Id = id;
        Name = name;
        
    }

    public void AddItem(Product item)
    {
        var alreadyExists = _item.Any(x => x.Name == item.Name);
        if (alreadyExists)
        {
            throw new ProductAlreadyAddedExceptions(Name, item.Name);
        }
    }
}