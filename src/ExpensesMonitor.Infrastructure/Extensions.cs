using ExpensesMonitor.Infrastructure.EF;
using ExpensesMonitor.Shared.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpensesMonitor.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructures(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        services.AddQueries();
        

        return services;
    }
}