using Microsoft.Extensions.DependencyInjection;
using MouseTracker.Application.Repository;
using MouseTracker.Infrastructure.Repository;

namespace MouseTracker.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITrackRepository, TrackRepository>();
        services.AddScoped<ApplicationDbContext>();

        return services;
    }
}