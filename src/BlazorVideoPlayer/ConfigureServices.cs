using BlazorVideoPlayer;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddVideoPlayerServices(this IServiceCollection services)
    {
        services.AddTransient<IVideoPlayerJsInterop, VideoPlayerJsInterop>();
        return services;
    }
}
