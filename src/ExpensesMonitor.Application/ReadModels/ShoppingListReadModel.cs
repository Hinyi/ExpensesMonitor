namespace ExpensesMonitor.Infrastructure.EF.Models;

internal class ShoppingListReadModel
{
    public Guid Id { get; set; }
    //public int Version { get; set; }
    public string Name { get; set; }
    //public PriceReadModel Price { get; set; }
    public ICollection<ProductListReadModel> Items { get; set; }
}