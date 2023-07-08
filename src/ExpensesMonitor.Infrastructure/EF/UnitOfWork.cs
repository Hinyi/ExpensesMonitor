using ExpensesMonitor.Domain.Repositories;
using ExpensesMonitor.Infrastructure.EF.Context;

namespace ExpensesMonitor.Infrastructure.EF;

public class UnitOfWork : IUnitOfWork
{
    private readonly ShoppingListDbContext _dbContext;

    public UnitOfWork(ShoppingListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}