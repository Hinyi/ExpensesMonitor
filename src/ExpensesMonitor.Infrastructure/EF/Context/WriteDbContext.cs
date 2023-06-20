using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;

namespace ExpensesMonitor.Infrastructure.EF.Context;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<ShoppingList> ShoppingLists { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("shopping");

        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<ShoppingList>(configuration);
        modelBuilder.ApplyConfiguration<ProductList>(configuration);
        
    }
}