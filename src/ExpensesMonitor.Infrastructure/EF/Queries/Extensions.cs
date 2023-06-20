using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Infrastructure.EF.Models;

namespace ExpensesMonitor.Infrastructure.EF.Queries;

internal static class Extensions
{
    public static ShoppingListDto AsDto(this ShoppingListReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Name = readModel.Name,
            Items = readModel.Items?.Select(
                x => new ProductListDto
                {
                    Name = x.Name,
                    Quantity = x.Quantity,
                    //price = x.Price
                })
        };
}