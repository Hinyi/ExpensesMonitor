using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Common;

namespace ExpensesMonitor.Domain.Entities;

public class Product : AuditableEntity
{
    public required ProductId Id { get; init;}
    public required ProductName Name { get; set; }
    public required Price price { get; set; }
    public required Quantity Quantity { get; set; }
    
    public CategoryId CategoryId { get; set; }
    public Category Category { get; set; }
    
    public AllergenCollection? Allergens { get; set; }
}