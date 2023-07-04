using ExpensesMonitor.Domain.Entities;

namespace ExpensesMonitor.Domain.ValueObjects;

public record ProductList (string Name, int Quantity, Price Price)
{
    //private readonly decimal TotalPrice = Quantity * Price.Amount;
    public Guid Id { get; set; } = new Guid();
    public ShoppingList ShoppingList { get; set; }
    // public ShoppingListId ShoppingListId { get; set; }
}