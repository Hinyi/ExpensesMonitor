using ExpensesMonitor.Application.DTO;

namespace ExpensesMonitor.Infrastructure.EF.Models;

internal class ProductListReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public PriceDto price { get; set; }
}