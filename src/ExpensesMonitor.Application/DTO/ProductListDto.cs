namespace ExpensesMonitor.Application.DTO;

public class ProductListDto
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public PriceDto price { get; set; }
    
}