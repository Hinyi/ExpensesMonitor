using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Shared.Domain;

namespace ExpensesMonitor.Domain.Events;

public record ProductRemoved(ShoppingList ShoppingList, Product Product) : IDomainEvent
{
    
}