using ExpensesMonitor.Domain;
using ExpensesMonitor.Domain.Policies;
using Microsoft.Extensions.DependencyInjection;
using ExpensesMonitor.Shared;
using ExpensesMonitor.Shared.Commands;
using Microsoft.AspNetCore.Builder;

namespace ExpensesMonitor.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddSingleton<IShoppingListFactory, ShoppingListFactory>();
        services.AddShared();

        services.Scan(x => x.FromAssemblies(typeof(IShoppingListPolicy).Assembly)
            .AddClasses(x => x.AssignableTo<IShoppingListPolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        return services;
    }
    
    public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
    {
        app.UseShared();
        return app;
    }

}