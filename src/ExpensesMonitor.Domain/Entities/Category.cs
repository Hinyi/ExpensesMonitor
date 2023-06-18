using ExpensesMonitor.Domain.ValueObjects;

namespace ExpensesMonitor.Domain.Entities;

public class Category
{
    public required CategoryId Id { get; init; }
    public required string Name { get; set; }
}