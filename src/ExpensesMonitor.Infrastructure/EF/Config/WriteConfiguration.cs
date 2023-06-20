using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpensesMonitor.Infrastructure.EF.Config;

public class WriteConfiguration : IEntityTypeConfiguration<ShoppingList>
    , IEntityTypeConfiguration<ProductList>
{
    public void Configure(EntityTypeBuilder<ShoppingList> builder)
    {
        builder.HasKey(x => x.Id);

        var shoppingListNameConverter = new ValueConverter<ShoppingListName, string>(
            x => x.ToString(),
            x => new ShoppingListName(x));

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, id => new ShoppingListId(id));

        builder.Property(typeof(ShoppingListName), "Name")
            .HasConversion(shoppingListNameConverter)
            .HasColumnName("Name");

        builder.HasMany(typeof(ProductList), "items");

        builder.ToTable("PackingList");
    }

    public void Configure(EntityTypeBuilder<ProductList> builder)
    {
        var priceConverter = new ValueConverter<Price, string>(x => x.ToString(),
            x => Price.Create(x));

        builder.Property<Guid>("Id");
        builder.Property(x => x.Name);
        builder.Property(x => x.Quantity);
        builder.Property(x => x.Price)
            .HasConversion(priceConverter);
        builder.ToTable("ProductList");
    }
}