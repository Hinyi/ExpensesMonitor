using ExpensesMonitor.Application.Services;
using ExpensesMonitor.Domain;
using ExpensesMonitor.Domain.Repositories;
using ExpensesMonitor.Infrastructure.EF.Context;
using ExpensesMonitor.Infrastructure.EF.Options;
using ExpensesMonitor.Infrastructure.EF.Repositories;
using ExpensesMonitor.Infrastructure.EF.Services;
using ExpensesMonitor.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesMonitor.Infrastructure.EF;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
        services.AddScoped<IShoppingListReadService, ShoppingListReadService>();

        var options = configuration.GetOptions<PostgresOptions>("Postgres");
        services.AddDbContext<ReadDbContext>(ctoox =>
            ctoox.UseNpgsql(options.ConnectionString));
        services.AddDbContext<WriteDbContext>(ctoox =>
            ctoox.UseNpgsql(options.ConnectionString));

        return services;
    }
}