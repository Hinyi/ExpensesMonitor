using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Shared.Domain;

namespace ExpensesMonitor.Domain.Events;

public record ProductAdded(ShoppingList ShoppingList, Product Product) : IDomainEvent;