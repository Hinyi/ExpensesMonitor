using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Shared.Common;

namespace ExpensesMonitor.Domain.Entities;

internal sealed class Allergen : AuditableEntity
{
    public required AllergenId Id { get; init; }
    public required string Name { get; set; }
}