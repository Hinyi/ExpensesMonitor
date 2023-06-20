using ExpensesMonitor.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesMonitor.Infrastructure.EF.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<ShoppingListReadModel>
    , IEntityTypeConfiguration<ProductListReadModel>
{
    public void Configure(EntityTypeBuilder<ShoppingListReadModel> builder)
    {
        builder.ToTable("ShoppingLists");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Price)
            .HasConversion(
                x => x.ToString(),
                x => PriceReadModel.Create(x));

        builder.HasMany(x => x.Items);
    }

    public void Configure(EntityTypeBuilder<ProductListReadModel> builder)
    {
        builder.ToTable("ProductLists");
    }
}