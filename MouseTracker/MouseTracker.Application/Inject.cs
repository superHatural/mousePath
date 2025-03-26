using Microsoft.Extensions.DependencyInjection;
using MouseTracker.Application.MouseTrack;
using MouseTracker.Application.Repository;

namespace MouseTracker.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateMouseTrackHandler>();

        return services;
    }
}