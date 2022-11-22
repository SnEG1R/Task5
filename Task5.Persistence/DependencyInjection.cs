using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task5.Application.Interfaces;
using Task5.Persistence.Contexts;

namespace Task5.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                               == "Production"
            ? configuration["ConnectionStrings:DefaultConnectionProduction"]
            : configuration["ConnectionStrings:DefaultConnectionDevelop"];


        services.AddDbContext<ApplicationVillageVillageDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IApplicationVillageDbContext, ApplicationVillageVillageDbContext>();
        services.AddScoped<DbContext, ApplicationVillageVillageDbContext>();

        return services;
    }
}