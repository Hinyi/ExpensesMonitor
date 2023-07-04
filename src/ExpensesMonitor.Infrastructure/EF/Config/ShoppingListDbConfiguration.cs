using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;
using ExpensesMonitor.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpensesMonitor.Infrastructure.EF.Config;

internal sealed class ShoppingListDbConfiguration : IEntityTypeConfiguration<ShoppingList>
    , IEntityTypeConfiguration<ProductList>
{
    public void Configure(EntityTypeBuilder<ShoppingList> builder)
    {
        builder.ToTable("ShoppingList");

        builder.HasKey(x => x.Id);

        var shoppingListNameConverter = new ValueConverter<ShoppingListName, string>(
            x => x.ToString(),
            x => new ShoppingListName(x));

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, id => new ShoppingListId(id));

        builder.Property(typeof(ShoppingListName), "Name")
            .HasConversion(shoppingListNameConverter)
            .HasColumnName("Name");

        builder.HasMany(x => x.Items)
            .WithOne(x => x.ShoppingList);
        //     .HasForeignKey(x => x.ShoppingListId.Value);
    }
    
    public void Configure(EntityTypeBuilder<ProductList> builder)
    {
        builder.ToTable("ProductList");
        builder.HasKey(x => x.Id);
        
        var priceConverter = new ValueConverter<Price, string>(x => x.ToString(),
            x => Price.Create(x));
        
        builder.Property<Guid>("Id");
        builder.Property(x => x.Name);
        builder.Property(x => x.Quantity);
        builder.Property(x => x.Price)
            .HasConversion(priceConverter);
    }
    
}