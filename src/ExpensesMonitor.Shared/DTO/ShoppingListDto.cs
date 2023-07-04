namespace ExpensesMonitor.Shared.DTO;

public class ShoppingListDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<ProductListDto>? Items { get; set; }
}