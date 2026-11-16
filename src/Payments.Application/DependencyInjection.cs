using Payments.Application.Interfaces;
using Payments.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Payments.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ITransactionService, TransactionService>();

        return services;
    }
}
