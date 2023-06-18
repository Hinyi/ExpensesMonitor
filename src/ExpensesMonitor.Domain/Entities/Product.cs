using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Common;

namespace ExpensesMonitor.Domain.Entities;

public class Product : AuditableEntity
{
    public ProductId Id { get; init;}
    public required ProductName Name { get; set; }
    public required Price price { get; set; }
    public required Quantity Quantity { get; set; }
    
    public CategoryId CategoryId { get; set; }
    public Category Category { get; set; }
    
    public AllergenCollection? Allergens { get; set; }

    public Product(ProductId id, ProductName name, Price price, Quantity quantity, CategoryId categoryId, Category category, AllergenCollection? allergens)
    {
        Id = id;
        Name = name;
        this.price = price;
        Quantity = quantity;
        CategoryId = categoryId;
        Category = category;
        Allergens = allergens;
    }
}