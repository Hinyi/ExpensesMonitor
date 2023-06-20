using ExpensesMonitor.Domain.Events;
using ExpensesMonitor.Domain.Exceptions;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Domain;

namespace ExpensesMonitor.Domain.Entities;

public class ShoppingList : AggregateRoot<ShoppingListId>
{
    public ShoppingListId Id { get; private set; }
    public ShoppingListName Name { get; private set; }

    private readonly LinkedList<ProductList> _items = new();

    private ShoppingList(ShoppingListId id, ShoppingListName name, LinkedList<ProductList> items)
        : this(id, name)
    {
        _items = items;
    }
    internal ShoppingList(Guid id, ShoppingListName name)
    {
        Id = id;
        Name = name;
    }

    public void AddItem(ProductList item)
    {
        var alreadyExists = _items.Any(x => x.Name == item.Name);
        if (alreadyExists)
        {
            throw new ProductAlreadyAddedExceptions(Name, item.Name);
        }

        _items.AddLast(item);
        AddEvent(new ProductAdded(this, item));
    }

    public void AddItems(IEnumerable<ProductList> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void RemoveItem(string itemName)
    {
        var item = GetItem(itemName);
        _items.Remove(item);
        AddEvent(new ProductRemoved(this, item));
    }

    private ProductList GetItem(string itemName)
    {
        var item = _items.SingleOrDefault(x => x.Name == itemName);

        if (item is null)
        {
            throw new Exception();
        }

        return item;
    }
}