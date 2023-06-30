using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Application.ReadModels;
using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;

namespace ExpensesMonitor.Infrastructure.EF.Context;

public class ShoppingListDbContext : DbContext
{
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    //public DbSet<ShoppingListReadModel> ShoppingListsRead { get; set; }
    // public DbSet<ProductList> ProductLists { get; set; }    

    public ShoppingListDbContext(DbContextOptions<ShoppingListDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("shopping");

        var configuration = new ShoppingListDbConfiguration();
        modelBuilder.ApplyConfiguration<ShoppingList>(configuration);
        modelBuilder.ApplyConfiguration<ProductList>(configuration);
        //modelBuilder.ApplyConfiguration<ProductListReadModel>(configuration);
        //modelBuilder.ApplyConfiguration<ShoppingListReadModel>(configuration);
    }

}