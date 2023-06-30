using ExpensesMonitor.Application.DTO;
using ExpensesMonitor.Application.ReadModels;
using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpensesMonitor.Infrastructure.EF.Config;

internal sealed class ShoppingListDbConfiguration : IEntityTypeConfiguration<ShoppingList>
    , IEntityTypeConfiguration<ProductList>, IEntityTypeConfiguration<ShoppingListReadModel>
, IEntityTypeConfiguration<ProductListReadModel>
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

        builder.HasMany(typeof(ProductList), "_items");

        //
        //
        // builder.HasMany(x => x.Items)
        //     .WithOne(x => x.);
    }

    public void Configure(EntityTypeBuilder<ShoppingListReadModel> builder)
    {
        builder.ToTable("ShoppingList");
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Items)
            .WithOne(x => x.ShoppingList);
    }

    public void Configure(EntityTypeBuilder<ProductList> builder)
    {
        builder.ToTable("ProductList");
        
        var priceConverter = new ValueConverter<Price, string>(x => x.ToString(),
            x => Price.Create(x));

        builder.Property<Guid>("Id");
        builder.Property(x => x.Name);
        builder.Property(x => x.Quantity);
        builder.Property(x => x.Price)
            .HasConversion(priceConverter);
    }

    public void Configure(EntityTypeBuilder<ProductListReadModel> builder)
    {
        builder.ToTable("ProductList");
    }
}