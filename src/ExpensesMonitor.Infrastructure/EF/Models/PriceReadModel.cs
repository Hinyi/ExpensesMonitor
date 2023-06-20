namespace ExpensesMonitor.Infrastructure.EF.Models;

internal class PriceReadModel
{
    public string currency { get; set; }
    public decimal amount { get; set; }

    public static PriceReadModel Create(string value)
    {
        var splitPrice = value.Split(",");
        return new PriceReadModel
        {
            currency = splitPrice.First(),
            amount = Convert.ToDecimal(splitPrice.Last())
        };
    }

    public override string ToString()
        => $"{currency},{amount}";
}