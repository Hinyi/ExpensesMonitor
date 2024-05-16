namespace ExpensesMonitor.Infrastructure.EF.Models;

public record AddNewProductToListReadModel(
    string name,
    int Quantity,
    PriceWriteModel price);

public record PriceWriteModel(
    string currency,
    decimal amount);