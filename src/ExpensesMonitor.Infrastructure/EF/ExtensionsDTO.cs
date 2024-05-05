using ExpensesMonitor.Domain.Entities;

namespace ExpensesMonitor.Shared.DTO;

internal static class ExtensionsDTO
{
    public static ShoppingListDto AsDto(this ShoppingList context)
        => new()
        {
            Name = context.Name,
            Id = context.Id,
            Items = context.Items.Select(pi => new ProductListDto
            {
                Name = pi.Name,
                Quantity = pi.Quantity,
                price = new PriceDto
                {
                    amount = pi.Price.Amount,
                    currency = pi.Price.Currency
                }
            })
        };
}