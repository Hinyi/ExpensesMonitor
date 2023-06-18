using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Domain;

namespace ExpensesMonitor.Domain.Events;

public record ProductAdded(ShoppingList ShoppingList,  ProductList ProductList) : IDomainEvent;