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
        services.AddDbContext<ApplicationVillageVillageDbContext>(options =>
        {
            options.UseNpgsql(configuration["ConnectionStrings:DefaultConnectionDevelop"]);
        });

        services.AddScoped<IApplicationVillageDbContext, ApplicationVillageVillageDbContext>();
        services.AddScoped<DbContext, ApplicationVillageVillageDbContext>();

        return services;
    }
}