using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Infrastructure.EF.Config;
using ExpensesMonitor.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesMonitor.Infrastructure.EF.Context;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<ShoppingListReadModel> ShoppingLists { get; set; }

    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("shopping");

        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<ShoppingListReadModel>(configuration);
        modelBuilder.ApplyConfiguration<ProductListReadModel>(configuration);
        
    }
}