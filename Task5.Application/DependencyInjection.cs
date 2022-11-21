using System.Reflection;
using Bogus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Task5.Application.Common.Generators;
using Task5.Application.Common.Generators.Interfaces;

namespace Task5.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}